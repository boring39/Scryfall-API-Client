using System.Net;

using ScryfallApi.Client.Models;

using static ScryfallApi.Client.Models.SearchOptions;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="ICards"/>
public class Cards : ICards
{
    private readonly BaseRestService _restService;
    private const string _baseEndPoint = "/cards";

    internal Cards(BaseRestService restService) => _restService = restService;

    public Task<ResultList<Card>> GetPage(int page, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ResultList<Card>>(new Uri($"/cards?page={page}"), cancellationToken: cancellationToken);

    public Task<Card> GetRandom(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/random"), false, cancellationToken);

    public Task<ResultList<Card>> Search(string query, int page, SortOrder sort, CancellationToken cancellationToken = default)
        => Search(query, page, new SearchOptions { Order = sort }, cancellationToken);

    public Task<ResultList<Card>> Search(string query, int page, SearchOptions options = default, CancellationToken cancellationToken = default)
    {
        if (page < 1)
        {
            page = 1;
        }

        query = WebUtility.UrlEncode(query);
        return _restService.GetAsync<ResultList<Card>>($"/cards/search?q={query}&page={page}&{options.BuildQueryString()}", cancellationToken: cancellationToken);
    }


    public Task<Card> GetByCollectorNumber(string setCode, string collectorNumber, string? lang = null, CancellationToken cancellationToken = default)
    {
        Uri requestUri = lang is null
            ? new($"{_baseEndPoint}/{setCode}/{collectorNumber}", UriKind.Relative)
            : new($"{_baseEndPoint}/{setCode}/{collectorNumber}/{lang}", UriKind.Relative);
        return _restService.GetAsync<Card>(requestUri, cancellationToken: cancellationToken);
    }
    public Task<Card> GetByMultiverseId(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/multiverse/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Card> GetByTcgPlayerId(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/tcgplayer/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Card> GetByMtgoId(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/mtgo/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Card> GetByArenaId(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/arena/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Card> GetByCardmarketId(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/cardmarket/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Card> GetByScryfallId(Guid id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<Card>(new Uri($"{_baseEndPoint}/{id}", UriKind.Relative), cancellationToken: cancellationToken);
}
