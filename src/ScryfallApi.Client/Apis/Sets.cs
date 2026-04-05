using System.Net;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="ISets"/>
internal class Sets : ISets
{
    private const string BaseEndpoint = "/sets";
    private const string TcgPlayerPath = "/tcgplayer";
    private readonly BaseRestService _restService;
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);

    internal Sets(BaseRestService restService) => _restService = restService;

    public Task<ResultList<SetObject>> GetAllSetsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ResultList<SetObject>>(BaseEndpointUri, cancellationToken: cancellationToken);

    public Task<SetObject> GetSetByCodeAsync(string setCode, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{WebUtility.UrlEncode(setCode)}", UriKind.Relative);
        return _restService.GetAsync<SetObject>(uri, cancellationToken: cancellationToken);
    }

    public Task<SetObject> GetSetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}", UriKind.Relative);
        return _restService.GetAsync<SetObject>(uri, cancellationToken: cancellationToken);
    }

    public Task<SetObject> GetSetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{TcgPlayerPath}/{id}", UriKind.Relative);
        return _restService.GetAsync<SetObject>(uri, cancellationToken: cancellationToken);
    }

}
