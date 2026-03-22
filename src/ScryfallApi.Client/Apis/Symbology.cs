using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="ISymbology"/>
public class Symbology : ISymbology
{
    private readonly BaseRestService _restService;

    internal Symbology(BaseRestService restService)
    {
        _restService = restService;
    }

    /// <summary>
    /// Retrieve all card symbols
    /// </summary>
    /// <returns></returns>
    public Task<ResultList<CardSymbol>> Get(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ResultList<CardSymbol>>("/symbology", cancellationToken: cancellationToken);

    /// <summary>
    /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
    /// </summary>
    /// <returns></returns>
    public Task<ManaCost> ParseMana(string cost, CancellationToken cancellationToken = default)
        => _restService.GetAsync<ManaCost>("/symbology/parse-mana", cancellationToken: cancellationToken);
}
