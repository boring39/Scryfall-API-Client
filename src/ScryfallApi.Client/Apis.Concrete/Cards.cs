using System.Net;

using ScryfallApi.Client.Models.QueryOptions;
using ScryfallApi.Models;

using static ScryfallApi.Client.Models.QueryOptions.SearchOptions;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ICards"/>
internal class Cards : ICards
{
    private readonly BaseRestService _restService;
    private const string CardsEndPoint = "/cards";

    internal Cards(BaseRestService restService) => _restService = restService;

    public Task<ListObject<CardObject>> GetPage(int page, CancellationToken cancellationToken = default)
        => _restService.GetListAsync<CardObject>(new Uri($"{CardsEndPoint}?page={page}", UriKind.Relative), cancellationToken: cancellationToken);

    public Task<CardObject> GetRandomAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/random", UriKind.Relative), false, cancellationToken);

    public Task<ListObject<CardObject>> Search(string query, int page, SortOrder sort, CancellationToken cancellationToken = default)
        => Search(query, page, new SearchOptions { Order = sort }, cancellationToken);

    public Task<ListObject<CardObject>> Search(string query, int page, SearchOptions options = default, CancellationToken cancellationToken = default)
    {
        if (page < 1)
        {
            page = 1;
        }

        return _restService.GetListAsync<CardObject>(BuildSearchUri(query, page, options), cancellationToken: cancellationToken);
    }

    public IAsyncEnumerable<CardObject> SearchAllAsync(string query, SortOrder sort, CancellationToken cancellationToken = default)
        => SearchAllAsync(query, new SearchOptions { Order = sort }, cancellationToken);

    public IAsyncEnumerable<CardObject> SearchAllAsync(string query, SearchOptions options = default, CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<CardObject>(BuildSearchUri(query, 1, options), cancellationToken);

    public IEnumerable<CardObject> SearchAll(string query, SortOrder sort, CancellationToken cancellationToken = default)
        => SearchAll(query, new SearchOptions { Order = sort }, cancellationToken);

    public IEnumerable<CardObject> SearchAll(string query, SearchOptions options = default, CancellationToken cancellationToken = default)
        => _restService.GetPaged<CardObject>(BuildSearchUri(query, 1, options), cancellationToken);

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


    public Task<CardObject> GetByCollectorNumber(string setCode, string collectorNumber, string? lang = null, CancellationToken cancellationToken = default)
    {
        Uri requestUri = lang is null
            ? new($"{CardsEndPoint}/{setCode}/{collectorNumber}", UriKind.Relative)
            : new($"{CardsEndPoint}/{setCode}/{collectorNumber}/{lang}", UriKind.Relative);
        return _restService.GetAsync<CardObject>(requestUri, cancellationToken: cancellationToken);
    }
    public Task<CardObject> GetByMultiverseIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/multiverse/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/tcgplayer/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetByMtgoIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/mtgo/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetByArenaIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/arena/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetByCardmarketIdAsync(int id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/cardmarket/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _restService.GetAsync<CardObject>(new Uri($"{CardsEndPoint}/{id}", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<CardObject> GetNamedCardAsync(NamedCardQuery query, CancellationToken cancellationToken = default)
    {
        var str = query.BuildQueryString();
        var uri = new Uri($"{CardsEndPoint}/named?{str}", UriKind.Relative);
        return _restService.GetAsync<CardObject>(uri, cancellationToken: cancellationToken);
    }
    public Task<Catalog> GetAutocompleteAsync(string q, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<ListObject<CardObject>> GetCollectionAsync(IEnumerable<CardIdentifier> identifiers, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
