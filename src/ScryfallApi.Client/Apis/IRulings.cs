using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>
/// Rulings represent Oracle rulings, Wizards of the Coast set release notes, or Scryfall notes for a particular card.
/// If two cards have the same name, they will have the same set of rulings objects. If a card has rulings, it usually
/// has more than one. Rulings with a scryfall source have been added by the Scryfall team, either to provide additional
/// context for the card, or explain how the card works in an unofficial format (such as Duel Commander).
/// </summary>
public interface IRulings
{
    /// <summary>
    /// Returns a <see cref="ScryfallList"> of rulings for a card with the given Multiverse ID.
    /// If the card has multiple multiverse IDs, this method can find either of them.
    /// </summary>
    /// <param name="id">The multiverse ID</param>
    Task<ScryfallRuling> GetByMultiverseIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns rulings for a card with the given MTGO ID (also known as the Catalog ID).
    /// The ID can either be the card’s mtgo_id or its mtgo_foil_id.
    /// </summary>
    /// <param name="id">The MTGO ID.</param>
    Task<ScryfallRuling> GetByMtgoIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary> Returns rulings for a card with the given Magic: The Gathering Arena ID. </summary>
    /// <param name="id">The Arena ID.</param>
    Task<ScryfallRuling> GetByArenaIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary> Returns a List of rulings for the card with the given set code and collector number. </summary>
    /// <param name="setCode">The three to five-letter set code. </param>
    /// <param name="collectorNumber">The collector number. </param>
    Task<ScryfallRuling> GetBySetCodeAndNumberAsync(string setCode, string collectorNumber, CancellationToken cancellationToken = default);

    /// <summary> Returns a List of rulings for a card with the given Scryfall ID. </summary>
    /// <param name="id">The Scryfall ID.</param>
    Task<ScryfallRuling> GetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default);
}