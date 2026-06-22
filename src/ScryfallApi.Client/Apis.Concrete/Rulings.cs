using System.Net;

using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

public sealed class Rulings : IRulings
{
    private const string BaseEndpoint = "/cards";
    private const string TrailingEndpoint = "/rulings";
    private const string MultiversePath = "/multiverse";
    private const string MtgoPath = "/mtgo";
    private const string ArenaPath = "/arena";
    private readonly BaseRestService _restService;

    internal Rulings(BaseRestService restService) => _restService = restService;
    public Task<ScryfallRuling> GetByArenaIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}{ArenaPath}/{id}{TrailingEndpoint}", UriKind.Relative);
        return _restService.GetAsync<ScryfallRuling>(uri, cancellationToken: cancellationToken);
    }
    public Task<ScryfallRuling> GetByMtgoIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}{MtgoPath}/{id}{TrailingEndpoint}", UriKind.Relative);
        return _restService.GetAsync<ScryfallRuling>(uri, cancellationToken: cancellationToken);
    }

    public Task<ScryfallRuling> GetByMultiverseIdAsync(Guid id, CancellationToken cancellationToken = default){
        Uri uri = new($"{BaseEndpoint}{MultiversePath}/{id}{TrailingEndpoint}", UriKind.Relative);
        return _restService.GetAsync<ScryfallRuling>(uri, cancellationToken: cancellationToken);
    }
    public Task<ScryfallRuling> GetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}{TrailingEndpoint}",UriKind.Relative);
        return _restService.GetAsync<ScryfallRuling>(uri, cancellationToken: cancellationToken);
    }
    public Task<ScryfallRuling> GetBySetCodeAndNumberAsync(string setCode, string collectorNumber, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{WebUtility.UrlEncode(setCode)}/{WebUtility.UrlEncode(collectorNumber)}{TrailingEndpoint}",UriKind.Relative);
        return _restService.GetAsync<ScryfallRuling>(uri, cancellationToken: cancellationToken);
    }
}