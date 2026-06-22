using System.Net;

using ScryfallApi.Client.Models.QueryOptions;
using ScryfallApi.Models;

using static ScryfallApi.Client.Models.QueryOptions.SearchOptions;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ICards"/>
internal sealed class Cards : ICards
{
    private readonly BaseRestService _restService;
    private const string CardsEndPoint = "/cards";

    internal Cards(BaseRestService restService) => _restService = restService;

    public Task<ScryfallList<ScryfallCard>> GetPage(int page, CancellationToken cancellationToken = default)
        => _restService.GetListAsync<ScryfallCard>(new Uri($"{CardsEndPoint}?page={page}", UriKind.Relative), cancellationToken: cancellationToken);

    public Task<ScryfallCard> GetRandomAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/random", UriKind.Relative), false, cancellationToken);

    public Task<ScryfallList<ScryfallCard>> Search(string query, int page, SortOrder sort, CancellationToken cancellationToken = default)
        => Search(query, page, new SearchOptions { Order = sort }, cancellationToken);

    public Task<ScryfallList<ScryfallCard>> Search(string query, int page, SearchOptions options = default, CancellationToken cancellationToken = default)
    {
        if (page < 1)
        {
            page = 1;
        }

        return _restService.GetListAsync<ScryfallCard>(BuildSearchUri(query, page, options), cancellationToken: cancellationToken);
    }

    public IAsyncEnumerable<ScryfallCard> SearchAllAsync(string query, SortOrder sort, CancellationToken cancellationToken = default)
        => SearchAllAsync(query, new SearchOptions { Order = sort }, cancellationToken);

    public IAsyncEnumerable<ScryfallCard> SearchAllAsync(string query, SearchOptions options = default, CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<ScryfallCard>(BuildSearchUri(query, 1, options), cancellationToken);

    public IEnumerable<ScryfallCard> SearchAll(string query, SortOrder sort, CancellationToken cancellationToken = default)
        => SearchAll(query, new SearchOptions { Order = sort }, cancellationToken);

    public IEnumerable<ScryfallCard> SearchAll(string query, SearchOptions options = default, CancellationToken cancellationToken = default)
        => _restService.GetPaged<ScryfallCard>(BuildSearchUri(query, 1, options), cancellationToken);

    private static Uri BuildSearchUri(string query, int page, SearchOptions options)
    {
        if (page < 1)
        {
            page = 1;
        }

        string encodedQuery = WebUtility.UrlEncode(query);
        string queryString = $"q={encodedQuery}&page={page}";
        string optionString = options.BuildQueryString();

        if (!string.IsNullOrEmpty(optionString))
        {
            queryString = $"{queryString}&{optionString}";
        }

        return new Uri($"{CardsEndPoint}/search?{queryString}", UriKind.Relative);
    }


    public Task<ScryfallCard> GetByCollectorNumber(string setCode, string collectorNumber, string? lang = null, CancellationToken cancellationToken = default)
    {
        Uri requestUri = lang is null
            ? new($"{CardsEndPoint}/{setCode}/{collectorNumber}", UriKind.Relative)
            : new($"{CardsEndPoint}/{setCode}/{collectorNumber}/{lang}", UriKind.Relative);
        return _restService.GetAsync<ScryfallCard>(requestUri, cancellationToken: cancellationToken);
    }
    public Task<ScryfallCard> GetByMultiverseIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/multiverse/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/tcgplayer/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetByMtgoIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/mtgo/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetByArenaIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/arena/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetByCardmarketIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/cardmarket/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCard>(new Uri($"{CardsEndPoint}/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<ScryfallCard> GetNamedCardAsync(NamedCardQuery query, CancellationToken cancellationToken = default)
    {
        var str = query.BuildQueryString();
        var uri = new Uri($"{CardsEndPoint}/named?{str}", UriKind.Relative);
        return _restService.GetAsync<ScryfallCard>(uri, cancellationToken: cancellationToken);
    }
    public Task<ScryfallCatalog> GetAutocompleteAsync(string q, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ScryfallList<ScryfallCard>> GetCollectionAsync(IEnumerable<CardIdentifier> identifiers, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}