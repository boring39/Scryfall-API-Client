using System.Net;

using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ISets"/>
internal sealed class Sets : ISets
{
    private const string BaseEndpoint = "/sets";
    private const string TcgPlayerPath = "/tcgplayer";
    private readonly BaseRestService _restService;
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);

    internal Sets(BaseRestService restService) => _restService = restService;

    public Task<ScryfallList<ScryfallSet>> GetAllSetsAsync(CancellationToken cancellationToken = default)
        => _restService.GetListAsync<ScryfallSet>(BaseEndpointUri, cancellationToken: cancellationToken);

    public IAsyncEnumerable<ScryfallSet> GetAllSetsAsyncEnumerable(CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<ScryfallSet>(BaseEndpointUri, cancellationToken);

    public Task<ScryfallSet> GetSetByCodeAsync(string setCode, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{WebUtility.UrlEncode(setCode)}", UriKind.Relative);
        return _restService.GetAsync<ScryfallSet>(uri, cancellationToken: cancellationToken);
    }

    public Task<ScryfallSet> GetSetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}", UriKind.Relative);
        return _restService.GetAsync<ScryfallSet>(uri, cancellationToken: cancellationToken);
    }

    public Task<ScryfallSet> GetSetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{TcgPlayerPath}/{id}", UriKind.Relative);
        return _restService.GetAsync<ScryfallSet>(uri, cancellationToken: cancellationToken);
    }

}