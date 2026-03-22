using System.Text.Json;

using Microsoft.Extensions.Caching.Memory;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

internal sealed class BaseRestService
{
    private readonly HttpClient _httpClient;
    private readonly ScryfallApiClientConfig _clientConfig;
    private readonly IMemoryCache? _cache;
    private readonly MemoryCacheEntryOptions? _cacheOptions;

    public BaseRestService(HttpClient httpClient, ScryfallApiClientConfig clientConfig, IMemoryCache? cache)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress ??= clientConfig.ScryfallApiBaseAddress;
        _clientConfig = clientConfig;
        _cache = cache;

        if (clientConfig.EnableCaching)
        {
            _cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _clientConfig.UseSlidingCacheExpiration ? null : _clientConfig.CacheDuration,
                SlidingExpiration = _clientConfig.UseSlidingCacheExpiration ? _clientConfig.CacheDuration : null,
            };
        }
    }

    public async Task<T> GetAsync<T>(Uri uri, bool useCache = true, CancellationToken cancellationToken = default) where T : BaseItem
    {
        string cacheKey = _httpClient.BaseAddress!.AbsoluteUri + uri;

        if (useCache && _cache is not null && _cache.TryGetValue(cacheKey, out T? cached))
        {
            return cached!;
        }

        HttpResponseMessage response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);
        Stream jsonStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        T obj = await JsonSerializer.DeserializeAsync<T>(jsonStream, cancellationToken: cancellationToken).ConfigureAwait(false) ?? throw new InvalidDataException(); // TODO: Improve this error handling

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

    public async Task<T> GetAsync<T>(string resourceUrl, bool useCache = true, CancellationToken cancellationToken = default) where T : BaseItem
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(resourceUrl, nameof(resourceUrl));
        Uri resourceUri = new(resourceUrl);
        return await GetAsync<T>(resourceUri, useCache, cancellationToken).ConfigureAwait(false);
    }
}
