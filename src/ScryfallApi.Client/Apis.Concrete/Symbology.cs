using System.Net;

using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ISymbology"/>
internal sealed class Symbology : ISymbology
{
    private const string BaseEndpoint = "/symbology";
    private const string ParseManaPath = "parse-mana?cost";
    private readonly BaseRestService _restService;
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);

    internal Symbology(BaseRestService restService)
    {
        _restService = restService;
    }

    public Task<ListObject<CardSymbol>> GetAsync(CancellationToken cancellationToken = default)
        => _restService.GetListAsync<CardSymbol>(BaseEndpointUri, cancellationToken: cancellationToken);

    public IAsyncEnumerable<CardSymbol> GetAllSymbolsAsyncEnumerable(CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<CardSymbol>(BaseEndpointUri, cancellationToken);

    public Task<ManaCost> ParseManaAsync(string cost, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{ParseManaPath}={WebUtility.UrlEncode(cost)}", UriKind.Relative);
        return _restService.GetAsync<ManaCost>(uri, cancellationToken: cancellationToken);
    }
}
