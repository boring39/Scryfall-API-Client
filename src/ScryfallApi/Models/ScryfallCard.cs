using System.Diagnostics.CodeAnalysis;

namespace ScryfallApi.Models;

/// <summary>
/// Card objects represent individual Magic: The Gathering cards that players could obtain and
/// add to their collection (with a few minor exceptions).
/// </summary>
public record ScryfallCard : ScryfallObject
{
    #region Core Card Fields

    /// <summary>
    /// This card’s Arena ID, if any. A large percentage of cards are not available on Arena and do not have this ID.
    /// </summary>
    public int? ArenaId { get; init; }

    /// <summary> A unique ID for this card in Scryfall’s database. </summary>
    public Guid Id { get; init; }

    /// <summary> A language code for this printing. </summary>
    public required string Language { get; init; }

    /// <summary>
    /// This card’s Magic Online ID (also known as the Catalog ID), if any. A large percentage
    /// of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    public int? MtgoId { get; init; }

    /// <summary>
    /// This card’s foil Magic Online ID (also known as the Catalog ID), if any. A large
    /// percentage of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    public int? MtgoFoilId { get; init; }

    /// <summary>
    /// This card’s multiverse IDs on Gatherer, if any, as an array of integers. Note that
    /// Scryfall includes many promo cards, tokens, and other esoteric objects that do not have
    /// these identifiers.
    /// </summary>
    public int[]? MultiverseIds { get; init; }

    /// <summary> This card's Resource ID on Gatherer, if any. </summary>
    public string? ResourceId { get; init; }

    /// <summary> This card's ID on TCGplayer's API, also known as the productId.</summary>
    public int? TcgplayerId { get; init; }

    /// <summary> This card's ID on TCGplayer's API, for its etched version if that version is a separate product. </summary>
    public int? TcgplayerEtchedId { get; init; }

    /// <summary> This card’s ID on Cardmarket’s API, also known as the idProduct. </summary>
    public int? CardMarketId { get; init; }

    /// <summary> A code for this card's layout. </summary>
    public required ScryfallCardLayout Layout { get; init; }

    /// <summary>
    /// A unique ID for this card’s oracle identity. This value is consistent across reprinted card editions,
    /// and unique among different cards with the same name (tokens, Unstable variants, etc). Always present except for
    /// the reversible_card layout where it will be absent; oracle_id will be found on each face instead.
    /// </summary>
    public Guid? OracleId { get; init; }

    /// <summary> A link to where you can begin paginating all re/prints for this card on Scryfall’s API. </summary>
    public required Uri PrintsSearchUri { get; init; }

    /// <summary> A link to this card’s rulings list on Scryfall’s API. </summary>
    public required Uri RulingsUri { get; init; }

    /// <summary> A link to this card’s permapage on Scryfall’s website. </summary>
    public required Uri ScryfallUri { get; init; }

    /// <summary> A link to this card object on Scryfall’s API. </summary>
    public required Uri Uri { get; init; }

    #endregion Core Card Fields

    #region Gameplay Fields

    /// <summary> If this card is closely related to other cards, this property will be an array with. </summary>
    public ScryfallRelatedCard[]? AllParts { get; init; }

    /// <summary> An array of Card Face objects, if this card is multifaced. </summary>
    public required ScryfallCardFace[]? CardFaces { get; init; }

    /// <summary>
    /// The card’s converted mana cost, now known as mana value. Note that some funny cards have fractional mana costs.
    /// </summary>
    public decimal Cmc { get; init; }

    /// <summary> This card’s color identity. </summary>
    public required ScryfallColors ColorIdentity { get; init; }

    /// <summary>
    /// The colors in this card’s color indicator, if any.A null value for this field indicates the card does not have one.
    /// </summary>
    public ScryfallColors? ColorIndicator { get; init; }

    /// <summary>
    /// This card’s colors, if the overall card has colors defined by the rules. Otherwise the colors will be on the
    /// card_faces objects, see below.
    /// </summary>
    public ScryfallColors? Colors { get; init; }

    /// <summary> This face's defense, if any. </summary>
    public string? Defense { get; init; }

    /// <summary> This card’s overall rank/popularity on EDHREC. Not all cards are ranked. </summary>
    public int? EdhrecRank { get; init; }

    /// <summary> True if this card is on the Commander Game Changer list. </summary>
    public bool? GameChanger { get; init; }

    /// <summary> This card’s hand modifier, if it is Vanguard card.This value will contain a delta, such as -1. </summary>
    public string? HandModifier { get; init; }

    /// <summary> An array of keywords that this card uses, such as 'Flying' and 'Cumulative upkeep'. </summary>
    public required string[] Keywords { get; init; }

    /// <summary> An object describing the legality of this card in different formats </summary>
    public required Dictionary<string, string> Legalities { get; init; } // TODO: Legalities Object?

    /// <summary> This card’s life modifier, if it is Vanguard card. This value will contain a delta, such as +2. </summary>
    public string? LifeModifier { get; init; }

    /// <summary> This loyalty if any. Note that some cards have loyalties that are not numeric, such as X. </summary>
    public string? Loyalty { get; init; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string "" if the cost is absent. Remember that per
    /// the game rules, a missing mana cost and a mana cost of {0} are different values.
    /// </summary>
    public string? ManaCost { get; init; }

    /// <summary>
    /// The name of this card. If this card has multiple faces, this field will contain both names separated by ␣//␣.
    /// </summary>
    public required string Name { get; init; }

    /// <summary> /// The Oracle text for this card, if any.  /// </summary>
    public string? OracleText { get; init; }

    /// <summary> This card's rank/popularity on Penny Dreadful. Not all cards are ranked. </summary>
    public int? PennyRank { get; init; }

    /// <summary> This card’s power, if any. Note that some cards have powers that are not numeric, such as *. </summary>
    public string? Power { get; init; }

    /// <summary> Colors of mana this this card could produce. </summary>
    public ScryfallColors? ProducedMana { get; init; }

    /// <summary> Indicates if this card is on the Reserved List. </summary>
    public bool Reserved { get; init; }

    /// <summary> This card’s toughness, if any. Note that some cards have toughnesses that are not numeric, such as *. </summary>
    public string? Toughness { get; init; }

    /// <summary> The type line of this card. </summary>
    public required string TypeLine { get; init; }

    #endregion Gameplay Fields

    #region Print Fields

    /// <summary> The name of the illustrator of this card. Newly spoiled cards may not have this field yet. </summary>
    public string? Artist { get; init; }

    /// <summary> The IDs of the artists that illustrated this card. Newly spoiled cards may not have this field yet. </summary>
    public Guid[]? ArtistIds { get; init; }

    /// <summary> The lit Unfinity attractions lights on this card, if any. </summary>
    public int[]? AttractionLights { get; init; } // TODO: Create Attraction Lights enum?

    /// <summary> Whether this card is found in boosters. </summary>
    public bool Booster { get; init; }

    /// <summary> This card's border color: black, white, borderless, yellow, silver, or gold. </summary>
    public required BorderColor BorderColor { get; init; }

    /// <summary> The Scryfall ID for the card back design present on this card. </summary>
    public Guid CardBackId { get; init; }

    /// <summary>
    /// The card's collector number. Note that collector numbers can contain non-numeric characters, such
    /// as letters or ★.
    /// </summary>
    public required string CollectorNumber { get; init; }

    /// <summary> True if you should consider avoiding use of this print downstream. </summary>
    public bool? ContentWarning { get; init; }

    /// <summary> True if this card was only released in a video game. </summary>
    public bool Digital { get; init; }

    /// <summary>
    /// An array of computer-readable flags that indicate if this card can come in foil, nonfoil, or etched finishes.
    /// </summary>
    public required Finish[] Finishes { get; init; }

    /// <summary> The just-for-fun name printed on the card (such as for Godzilla series cards). </summary>
    public string? FlavorName { get; init; }

    /// <summary> The flavor text, if any. </summary>
    public string? FlavorText { get; init; }

    /// <summary> This card's frame effects, if any. </summary>
    public FrameEffect[]? FrameEffects { get; init; }

    /// <summary> This card's frame layout </summary>
    public Frame Frame { get; init; }

    /// <summary> True if this card’s artwork is larger than normal. </summary>
    public bool FullArt { get; init; }

    /// <summary> A list of games that this card print is available in, paper, arena, mtgo, astral, and/or sega. </summary>
    public required Game[] Games { get; init; }

    /// <summary> True if this card's imagery is high resolution. </summary>
    public bool HighresImage { get; init; }

    /// <summary>
    /// A unique identifier for the card artwork that remains consistent across reprints. Newly spoiled
    /// cards may not have this field yet.
    /// </summary>
    public Guid? IllustrationId { get; init; }

    /// <summary>
    /// A computer-readable indicator for the state of this card’s image, one of missing, placeholder, lowres, or highres_scan.
    /// </summary>
    public required ImageStatus ImageStatus { get; init; }

    /// <summary>
    /// An object listing available imagery for this card. See the Card Imagery article for more information.
    /// </summary>
    public ImageUrisObject? ImageUris { get; init; }

    /// <summary> True if this card is oversized. </summary>
    public bool Oversized { get; init; }

    /// <summary>
    /// An object containing daily price information for this card, including usd, usd_foil, usd_etched, eur, eur_foil,
    /// eur_etched, and tix prices, as strings.
    /// </summary>
    public required PricesObject Prices { get; init; }

    /// <summary> The localized name printed on this card, if any. </summary>
    public string? PrintedName { get; init; }

    /// <summary> The localized text printed on this card, if any. </summary>
    public string? PrintedText { get; init; }

    /// <summary> The localized type line printed on this card, if any. </summary>
    public string? PrintedTypeLine { get; init; }

    /// <summary> True if this card is a promotional print. </summary>
    public bool Promo { get; init; }

    /// <summary>  An array of strings describing what categories of promo cards this card falls into. </summary>
    public string[]? PromoTypes { get; init; }

    /// <summary> An object providing URIs to this card's listing on major marketplaces. Omitted if the card is unpurchaseable.  </summary>
    public Dictionary<string, Uri>? PurchaseUris { get; init; }

    /// <summary> This card's rarity. One of common, uncommon, rare, special, mythic, or bonus. </summary>
    public required Rarity Rarity { get; init; }

    /// <summary> An object providing URIs to this card's listing on other Magic: The Gathering online resources. </summary>
    public required Dictionary<string, Uri> RelatedUris { get; init; }

    /// <summary> The date this card was first released. </summary>
    public required string ReleasedAt { get; init; }

    /// <summary> True if this card is a reprint. </summary>
    public bool Reprint { get; init; }

    /// <summary> A link to this card's set on Scryfall's website. </summary>
    public required Uri ScryfallSetUri { get; init; }

    /// <summary> This card's full set name. </summary>
    public required string SetName { get; init; }

    /// <summary> A link to where you can begin paginating this card's set on the Scryfall API. </summary>
    public required Uri SetSearchUri { get; init; }

    /// <summary> The type of set this printing is in. </summary>
    public required string SetType { get; init; }

    /// <summary> A link to this card's set object on Scryfall's API. </summary>
    public required Uri SetUri { get; init; }

    /// <summary> This card's set code. </summary>
    public required string Set { get; init; }

    /// <summary> This card's Set object UUID. </summary>
    public Guid SetId { get; init; }

    /// <summary> True if this card is a Story Spotlight. </summary>
    public bool StorySpotlight { get; init; }

    /// <summary> True if the card is printed without text. </summary>
    public bool Textless { get; init; }

    /// <summary>Whether this card is a variation of another printing. </summary>
    [MemberNotNullWhen(true, nameof(VariationOf))]
    public bool Variation { get; init; }

    /// <summary> The printing ID of the printing this card is a variation of. </summary>
    public Guid? VariationOf { get; init; }

    /// <summary> The security stamp on this card, if any. One of oval, triangle, acorn, circle, arena, or heart. </summary>
    public SecurityStamp? SecurityStamp { get; init; }

    /// <summary> This card's watermark, if any. </summary>
    public string? Watermark { get; init; }
    public Preview? Preview { get; init; }

    #endregion Print Fields
}