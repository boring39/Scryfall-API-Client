using System.Net;

using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ISets"/>
internal class Sets : ISets
{
    private const string BaseEndpoint = "/sets";
    private const string TcgPlayerPath = "/tcgplayer";
    private readonly BaseRestService _restService;
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);

    internal Sets(BaseRestService restService) => _restService = restService;

    public Task<ListObject<Set>> GetAllSetsAsync(CancellationToken cancellationToken = default)
        => _restService.GetListAsync<Set>(BaseEndpointUri, cancellationToken: cancellationToken);

    public IAsyncEnumerable<Set> GetAllSetsAsyncEnumerable(CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<Set>(BaseEndpointUri, cancellationToken);

    public Task<Set> GetSetByCodeAsync(string setCode, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{WebUtility.UrlEncode(setCode)}", UriKind.Relative);
        return _restService.GetAsync<Set>(uri, cancellationToken: cancellationToken);
    }

    public Task<Set> GetSetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}", UriKind.Relative);
        return _restService.GetAsync<Set>(uri, cancellationToken: cancellationToken);
    }

    public Task<Set> GetSetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{TcgPlayerPath}/{id}", UriKind.Relative);
        return _restService.GetAsync<Set>(uri, cancellationToken: cancellationToken);
    }

}
