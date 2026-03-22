using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>
/// A Catalog object contains an array of Magic datapoints (words, card values, etc). Catalog objects
/// are provided by the API as aids for building other Magic software and understanding possible
/// values for a field on Card objects.
/// </summary>
public interface ICatalogs
{
    /// <summary>
    /// Returns a list of all nontoken English card names in Scryfall’s database. Values are updated as
    /// soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListCardNames(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of all canonical artist names in Scryfall’s database. This catalog won’t include duplicate,
    /// misspelled, or funny names for artists. Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    Task<Catalog> ListArtistNames(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all English words, of length 2 or more, that could appear in a card name.
    /// Values are drawn from cards currently in Scryfall’s database. Values are updated as soon as a
    /// new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListWordBank(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all Magic card supertypes. Values are updated as soon as a new card is entered
    /// for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListSuperTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all Magic card types. Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListCardTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all artifact types in Scryfall’s database. Values are updated as soon as a
    /// new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListArtifactTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all Battle types in Scryfall’s database. Values are updated as soon as a new card is
    /// entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListBattleTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all creature types in Scryfall’s database. Values are updated as soon as
    /// a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListCreatureTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all enchantment types in Scryfall’s database. Values are updated as soon as a
    /// new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListEnchantmentTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all Land types in Scryfall’s database. Values are updated as soon as a new
    /// card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListLandTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all Planeswalker types in Scryfall’s database. Values are updated as soon as
    /// a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListPlaneswalkerTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all spell types in Scryfall’s database. Values are updated as soon as a new
    /// card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListSpellTypes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all possible values for a creature or vehicle’s power in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListPowers(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all possible values for a creature or vehicle’s toughness in Scryfall’s database.
    /// Values are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListToughnesses(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all possible values for a Planeswalker’s loyalty in Scryfall’s database. Values
    /// are updated as soon as a new card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListLoyalties(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all keyword abilities in Scryfall’s database. Values are updated as soon as a new card
    /// is entered for spoiler seasons.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <Catalog></returns>
    Task<Catalog> ListKeywordAbilities(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all keyword actions in Scryfall’s database. Values are updated as soon as a new card is
    /// entered for spoiler seasons.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Catalog> ListKeywordActions(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all ability words in Scryfall’s database. Values are updated as soon as a new card is
    /// entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListAbilityWords(CancellationToken cancellationToken = default);

    /// <summary> Returns a Catalog of all flavor words in Scryfall’s database. </summary>
    /// <returns></returns>
    Task<Catalog> ListFlavorWords(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a Catalog of all card watermarks in Scryfall’s database. Values are updated as soon as a new
    /// card is entered for spoiler seasons.
    /// </summary>
    /// <returns></returns>
    Task<Catalog> ListWatermarks(CancellationToken cancellationToken = default);
}
