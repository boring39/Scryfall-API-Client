using ScryfallApi.Client.Models.QueryOptions;
using ScryfallApi.Models;

using static ScryfallApi.Client.Models.QueryOptions.SearchOptions;

namespace ScryfallApi.Client.Apis;

/// <summary>
/// APIs for cards. Card objects represent individual Magic: The Gathering cards that players could
/// obtain and add to their collection (with a few minor exceptions).
/// </summary>
public interface ICards
{
    /// <summary> Fetch a card at random. </summary>
    /// <returns></returns>
    Task<ScryfallCard> GetRandomAsync(CancellationToken cancellationToken = default);

    /// <summary> Get a page worth of cards </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    Task<ScryfallList<ScryfallCard>> GetPage(int page, CancellationToken cancellationToken = default);

    /// <summary> Search for cards with a sort option </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <param name="sort"></param>
    /// <returns></returns>
    Task<ScryfallList<ScryfallCard>> Search(string query, int page, SortOrder sort, CancellationToken cancellationToken = default);

    /// <summary> Search for cards using the full search options available </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<ScryfallList<ScryfallCard>> Search(string query, int page, SearchOptions options, CancellationToken cancellationToken = default);

    /// <summary> Stream all matching cards from the search result pages asynchronously. </summary>
    IAsyncEnumerable<ScryfallCard> SearchAllAsync(string query, SearchOptions options = default, CancellationToken cancellationToken = default);

    /// <summary> Stream all matching cards from the search result pages asynchronously, using sort semantics. </summary>
    IAsyncEnumerable<ScryfallCard> SearchAllAsync(string query, SortOrder sort, CancellationToken cancellationToken = default);

    /// <summary> Stream all matching cards from the search result pages synchronously. </summary>
    IEnumerable<ScryfallCard> SearchAll(string query, SearchOptions options = default, CancellationToken cancellationToken = default);

    /// <summary> Stream all matching cards from the search result pages synchronously, using sort semantics. </summary>
    IEnumerable<ScryfallCard> SearchAll(string query, SortOrder sort, CancellationToken cancellationToken = default);

    Task<ScryfallCard> GetNamedCardAsync(NamedCardQuery query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog object containing up to 20 full English card names that could be autocompletions of the given string parameter.
    /// This method is designed for creating assistive UI elements that allow users to free-type card names.
    /// The names are sorted with the nearest match first, highly favoring results that begin with your given string.
    /// Spaces, punctuation, and capitalization are ignored.
    /// If <paramref name="q"/> is less than 2 characters long, or if no names match, the Catalog will contain 0 items (instead of returning any errors).
    /// </summary>
    /// <param name="q"> The string to autocomplete. </param>
    Task<ScryfallCatalog> GetAutocompleteAsync(string q, CancellationToken cancellationToken = default);

    Task<ScryfallList<ScryfallCard>> GetCollectionAsync(IEnumerable<CardIdentifier> identifiers, CancellationToken cancellationToken = default);

    // :Code /:number / :lang

    /// <summary>
    /// Returns a single card with the given Multiverse ID. If the card has multiple multiverse IDs,
    /// this method can find either of them.
    /// </summary>
    Task<ScryfallCard> GetByMultiverseIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single card with the given MTGO ID (also known as the Catalog ID). The ID can either be the card’s
    /// mtgo_id or its mtgo_foil_id.
    /// </summary>
    Task<ScryfallCard> GetByMtgoIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary> Returns a single card with the given Magic: The Gathering Arena ID.</summary>
    Task<ScryfallCard> GetByArenaIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single card with the given tcgplayer_id or tcgplayer_etched_id, also known as the productId on TCGplayer’s API.
    /// </summary>
    Task<ScryfallCard> GetByTcgPlayerIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single card with the given cardmarket_id, also known as the idProduct" or the
    /// Product ID on Cardmarket’s APIs.
    /// </summary>
    Task<ScryfallCard> GetByCardmarketIdAsync(int id, CancellationToken cancellationToken = default);

    ///<summary> Returns a single card with the given Scryfall ID. </summary>
    Task<ScryfallCard> GetByScryfallIdAsync(Guid id, CancellationToken cancellationToken = default);
}