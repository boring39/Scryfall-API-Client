using System.Net;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

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

    public Task<ResultList<CardSymbol>> GetAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ResultList<CardSymbol>>(BaseEndpointUri, cancellationToken: cancellationToken);

    public Task<ManaCost> ParseManaAsync(string cost, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{ParseManaPath}={WebUtility.UrlEncode(cost)}", UriKind.Relative);
        return _restService.GetAsync<ManaCost>(uri, cancellationToken: cancellationToken);
    }
}
