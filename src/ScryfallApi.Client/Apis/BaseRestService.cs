using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.RateLimiting;

using Microsoft.Extensions.Caching.Memory;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

internal sealed class BaseRestService : IDisposable, IAsyncDisposable
{
    private bool _disposed = false;
    private readonly HttpClient _httpClient;
    private readonly ScryfallApiClientConfig _clientConfig;
    private readonly IMemoryCache? _cache;
    private readonly MemoryCacheEntryOptions? _cacheOptions;
    private readonly RateLimiter _searchLimiter;
    private readonly RateLimiter _defaultLimiter;

    internal BaseRestService(HttpClient httpClient, ScryfallApiClientConfig clientConfig, IMemoryCache? cache)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress ??= clientConfig.ScryfallApiBaseAddress;
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("CardCollector", "1.0"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _clientConfig = clientConfig;
        _cache = cache;

        _searchLimiter = new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions
        {
            PermitLimit = 2,
            Window = TimeSpan.FromSeconds(1),
            QueueLimit = 200,
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst
        });

        _defaultLimiter = new FixedWindowRateLimiter(new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromSeconds(1),
            QueueLimit = 200,
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst
        });

        if (clientConfig.EnableCaching)
        {
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _clientConfig.UseSlidingCacheExpiration ? null : _clientConfig.CacheDuration,
                SlidingExpiration = _clientConfig.UseSlidingCacheExpiration ? _clientConfig.CacheDuration : null,
            };
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _defaultLimiter.Dispose();
            _searchLimiter.Dispose();
        }

        _disposed = true;
    }
    public async ValueTask DisposeAsync()
    {
        await _defaultLimiter.DisposeAsync().ConfigureAwait(false);
        await _searchLimiter.DisposeAsync().ConfigureAwait(false);
        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    internal async Task<T> GetAsync<T>(Uri uri, bool useCache = true, CancellationToken cancellationToken = default) where T : BaseObject
    {
        string cacheKey = _httpClient.BaseAddress!.AbsoluteUri + uri;

        if (useCache && _cache is not null && _cache.TryGetValue(cacheKey, out T? cached))
        {
            return cached!;
        }

        using HttpRequestMessage request = new(HttpMethod.Get, uri);
        using HttpResponseMessage response = await SendAsync(request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        using Stream jsonStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        T? obj = await JsonSerializer.DeserializeAsync<T>(jsonStream, cancellationToken: cancellationToken).ConfigureAwait(false);
        if (obj is null)
        {
            string body = ""; // TODO: get the body from the attempted deserialization
            throw new JsonException($"Failed to deserialize response into {typeof(T).Name}. Body: {body}");
        }

        if (obj.ObjectType.Equals("error", StringComparison.OrdinalIgnoreCase))
        {
            jsonStream.Position = 0;
            ErrorObject error = await JsonSerializer.DeserializeAsync<ErrorObject>(jsonStream, cancellationToken: cancellationToken).ConfigureAwait(false) ?? throw new InvalidDataException(); // TODO: Improve this error handling
            throw new ScryfallApiException(error.Details)
            {
                ResponseStatusCode = response.StatusCode,
                RequestUri = response.RequestMessage?.RequestUri!, // TODO: Null checks
                RequestMethod = response.RequestMessage?.Method!, // TODO: Null checks
                ScryfallError = error
            };
        }

        if (useCache)
        {
            _ = _cache?.Set(cacheKey, obj, _cacheOptions);
        }

        return obj;

    }

    private RateLimiter GetLimiterFor(string path)
    {
        if (path.StartsWith("/cards/search", StringComparison.OrdinalIgnoreCase) ||
            path.StartsWith("/cards/named", StringComparison.OrdinalIgnoreCase) ||
            path.StartsWith("/cards/random", StringComparison.OrdinalIgnoreCase) ||
            path.StartsWith("/cards/collection", StringComparison.OrdinalIgnoreCase))
        {
            return _searchLimiter;
        }

        return _defaultLimiter;
    }

    /// <summary>
    /// Rate limiting to comply with Scryfall API requirements.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken = default)
    {
        RateLimiter limiter = GetLimiterFor(request.RequestUri!.AbsolutePath);

        using RateLimitLease lease = await limiter.AcquireAsync(1, cancellationToken);

        HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        {
            // Scryfall requires a 30-second cooldown
            await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);

            response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        return response;
    }

}
