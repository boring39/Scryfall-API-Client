using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>
/// APIs for card symbols. A Card Symbol object represents an illustrated symbol that may appear in card’s
/// mana cost or Oracle text. Symbols are based on the notation used in the Comprehensive Rules.
/// </summary>
public interface ISymbology
{
    /// <summary>
    /// Retrieve all card symbols
    /// </summary>
    /// <returns></returns>
    Task<ResultList<CardSymbol>> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
    /// </summary>
    /// <returns></returns>
    Task<ManaCost> ParseManaAsync(string cost, CancellationToken cancellationToken = default);
}
