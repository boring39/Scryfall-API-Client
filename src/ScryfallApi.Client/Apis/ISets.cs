using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>
/// APIs for card sets. A Set object represents a group of related Magic cards. All Card objects on
/// Scryfall belong to exactly one set.
/// </summary>
public interface ISets
{
    /// <summary> Returns a <see cref="ListObject">List Object</see> of all <see cref="Set">Sets</see> on Scryfall. </summary>
    Task<ListObject<Set>> GetAllSetsAsync(CancellationToken cancellationToken = default);

    /// <summary> Stream all sets asynchronously across any paginated result pages. </summary>
    IAsyncEnumerable<Set> GetAllSetsAsyncEnumerable(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Set with the given set code. The code can be either the code or the mtgo_code for the set.
    /// </summary>
    /// <param name="setCode">The three to five-letter set code.</param>
    Task<Set> GetSetByCodeAsync(string setCode, CancellationToken cancellationToken = default);

    /// <summary> Returns a Set with the given tcgplayer_id, also known as the groupId on TCGplayer’s API. </summary>
    /// <param name="id">The tcgplayer_id or groupId.</param>
    Task<Set> GetSetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary> Returns a Set with the given Scryfall id. </summary>
    /// <param name="id">The Scryfall ID</param>
    Task<Set> GetSetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default);
}
