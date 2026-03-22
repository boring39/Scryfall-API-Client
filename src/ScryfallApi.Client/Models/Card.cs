using System.Text.Json.Serialization;

using ScryfallApi.Client.Converters;


namespace ScryfallApi.Client.Models;

/// <summary>
/// Card objects represent individual Magic: The Gathering cards that players could obtain and
/// add to their collection (with a few minor exceptions).
/// </summary>
public record Card : BaseItem
{
    #region Core Card Fields

    /// <summary>
    /// This card’s Arena ID, if any. A large percentage of cards are not available on Arena and do not have this ID.
    /// </summary>
    [JsonPropertyName("arena_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ArenaId { get; init; }

    /// <summary> A unique ID for this card in Scryfall’s database. </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    /// <summary> A language code for this printing. </summary>
    [JsonPropertyName("lang")]
    public required string Language { get; init; }

    /// <summary>
    /// This card’s Magic Online ID (also known as the Catalog ID), if any. A large percentage
    /// of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    [JsonPropertyName("mtgo_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MtgoId { get; init; }

    /// <summary>
    /// This card’s foil Magic Online ID (also known as the Catalog ID), if any. A large
    /// percentage of cards are not available on Magic Online and do not have this ID.
    /// </summary>
    [JsonPropertyName("mtgo_foil_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MtgoFoilId { get; init; }

    /// <summary>
    /// This card’s multiverse IDs on Gatherer, if any, as an array of integers. Note that
    /// Scryfall includes many promo cards, tokens, and other esoteric objects that do not have
    /// these identifiers.
    /// </summary>
    [JsonPropertyName("multiverse_ids")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<int>? MultiverseIds { get; init; }

    /// <summary> This card's Resource ID on Gatherer, if any. </summary>
    [JsonPropertyName("resource_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ResourceId { get; init; }

    /// <summary> This card's ID on TCGplayer's API, also known as the productId.</summary>
    [JsonPropertyName("tcgplayer_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TcgplayerId { get; init; }

    /// <summary> This card's ID on TCGplayer's API, for its etched version if that version is a separate product. </summary>
    [JsonPropertyName("tcgplayer_etched_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TcgplayerEtchedId { get; init; }

    /// <summary> This card’s ID on Cardmarket’s API, also known as the idProduct. </summary>
    [JsonPropertyName("cardmarket_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CardMarketId { get; init; }

    /// <summary> A code for this card's layout. </summary>
    [JsonPropertyName("layout")]
    public required string Layout { get; init; }

    /// <summary>
    /// A unique ID for this card’s oracle identity. This value is consistent across reprinted card editions,
    /// and unique among different cards with the same name (tokens, Unstable variants, etc). Always present except for
    /// the reversible_card layout where it will be absent; oracle_id will be found on each face instead.
    /// </summary>
    [JsonPropertyName("oracle_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? OracleId { get; init; }

    /// <summary> A link to where you can begin paginating all re/prints for this card on Scryfall’s API. </summary>
    [JsonPropertyName("prints_search_uri")]
    public required Uri PrintsSearchUri { get; init; }

    /// <summary> A link to this card’s rulings list on Scryfall’s API. </summary>
    [JsonPropertyName("rulings_uri")]
    public required Uri RulingsUri { get; init; }

    /// <summary> A link to this card’s permapage on Scryfall’s website. </summary>
    [JsonPropertyName("scryfall_uri")]
    public required Uri ScryfallUri { get; init; }

    /// <summary> A link to this card object on Scryfall’s API. </summary>
    [JsonPropertyName("uri")]
    public required Uri Uri { get; init; }

    #endregion Core Card Fields

    #region Gameplay Fields

    /// <summary> If this card is closely related to other cards, this property will be an array with. </summary>
    [JsonPropertyName("all_parts")]
    public IReadOnlyList<RelatedCard>? AllParts { get; init; }

    /// <summary> An array of Card Face objects, if this card is multifaced. </summary>
    [JsonPropertyName("card_faces")]
    public IReadOnlyList<CardFace>? CardFaces { get; init; }

    /// <summary>
    /// The card’s converted mana cost, now known as mana value. Note that some funny cards have fractional mana costs.
    /// </summary>
    [JsonPropertyName("cmc")]
    public decimal Cmc { get; init; }

    /// <summary> This card’s color identity. </summary>
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonPropertyName("color_identity")]
    public required Colors ColorIdentity { get; init; }

    /// <summary>
    /// The colors in this card’s color indicator, if any.A null value for this field indicates
    /// the card does not have one.
    /// </summary>
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonPropertyName("color_indicator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Colors? ColorIndicator { get; init; }

    /// <summary>
    /// This card’s colors, if the overall card has colors defined by the rules. Otherwise the colors will be on the
    /// card_faces objects, see below.
    /// </summary>
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonPropertyName("colors")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Colors? Colors { get; init; }

    /// <summary> This face's defense, if any. </summary>
    [JsonPropertyName("defense")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Defense { get; init; }

    /// <summary> This card’s overall rank/popularity on EDHREC. Not all cards are ranked. </summary>
    [JsonPropertyName("edhrec_rank")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EdhrecRank { get; init; }

    /// <summary> True if this card is on the Commander Game Changer list. </summary>
    [JsonPropertyName("game_changer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? GameChanger { get; init; }

    /// <summary> This card’s hand modifier, if it is Vanguard card.This value will contain a delta, such as -1. </summary>
    [JsonPropertyName("hand_modifier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HandModifier { get; init; }

    /// <summary> An array of keywords that this card uses, such as 'Flying' and 'Cumulative upkeep'. </summary>
    [JsonPropertyName("keywords")]
    public required IReadOnlyList<string> Keywords { get; init; }

    /// <summary> An object describing the legality of this card in different formats </summary>
    [JsonPropertyName("legalities")]
    public required Dictionary<string, string> Legalities { get; init; } // TODO: Legalities Object?

    /// <summary>
    /// This card’s life modifier, if it is Vanguard card. This value will contain a delta, such as +2.
    /// </summary>
    [JsonPropertyName("life_modifier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LifeModifier { get; init; }

    /// <summary>
    /// This loyalty if any. Note that some cards have loyalties that are not numeric, such as X.
    /// </summary>
    [JsonPropertyName("loyalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Loyalty { get; init; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string "" if the cost is
    /// absent. Remember that per the game rules, a missing mana cost and a mana cost of {0} are
    /// different values.
    /// </summary>
    [JsonPropertyName("mana_cost")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ManaCost { get; init; }

    /// <summary>
    /// The name of this card. If this card has multiple faces, this field will contain both
    /// names separated by ␣//␣.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary> /// The Oracle text for this card, if any.  /// </summary>
    [JsonPropertyName("oracle_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OracleText { get; init; }

    /// <summary> This card's rank/popularity on Penny Dreadful. Not all cards are ranked. </summary>
    [JsonPropertyName("penny_rank")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PennyRank { get; init; }

    /// <summary>
    /// This card’s power, if any. Note that some cards have powers that are not numeric, such as *.
    /// </summary>
    [JsonPropertyName("power")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Power { get; init; }

    /// <summary>
    /// Colors of mana this this card could produce.
    /// </summary>
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonPropertyName("produced_mana")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Colors? ProducedMana { get; init; }

    /// <summary> Indicates if this card is on the Reserved List. </summary>
    [JsonPropertyName("reserved")]
    public bool Reserved { get; init; }

    /// <summary>
    /// This card’s toughness, if any. Note that some cards have toughnesses that are not numeric, such as *.
    /// </summary>
    [JsonPropertyName("toughness")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Toughness { get; init; }

    /// <summary> The type line of this card. </summary>
    [JsonPropertyName("type_line")]
    public required string TypeLine { get; init; }

    #endregion Gameplay Fields

    #region Print Fields

    /// <summary>
    /// The name of the illustrator of this card. Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonPropertyName("artist")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Artist { get; init; }

    /// <summary>
    /// The IDs of the artists that illustrated this card. Newly spoiled cards may not have this field yet.
    /// </summary>
    [JsonPropertyName("artist_ids")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Guid>? ArtistIds { get; init; }

    /// <summary> The lit Unfinity attractions lights on this card, if any. </summary>
    [JsonPropertyName("attraction_lights")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<int>? AttractionLights { get; init; } // TODO: Create Attraction Lights enum?

    /// <summary> Whether this card is found in boosters. </summary>
    [JsonPropertyName("booster")]
    public bool Booster { get; init; }

    /// <summary> This card's border color: black, white, borderless, yellow, silver, or gold. </summary>
    [JsonPropertyName("border_color")]
    public required string BorderColor { get; init; }

    /// <summary> The Scryfall ID for the card back design present on this card. </summary>
    [JsonPropertyName("card_back_id")]
    public required Guid CardBackId { get; init; }

    /// <summary>
    /// The card's collector number. Note that collector numbers can contain non-numeric characters, such
    /// as letters or ★.
    /// </summary>
    [JsonPropertyName("collector_number")]
    public required string CollectorNumber { get; init; }

    /// <summary> True if you should consider avoiding use of this print downstream. </summary>
    [JsonPropertyName("content_warning")]
    public bool? ContentWarning { get; init; }

    /// <summary> True if this card was only released in a video game. </summary>
    [JsonPropertyName("digital")]
    public bool Digital { get; init; }

    /// <summary>
    /// An array of computer-readable flags that indicate if this card can come in foil, nonfoil, or etched finishes.
    /// </summary>
    [JsonPropertyName("finishes")]
    public required IReadOnlyList<string> Finishes { get; init; } // TODO: Create Finishes

    /// <summary> The just-for-fun name printed on the card (such as for Godzilla series cards). </summary>
    [JsonPropertyName("flavor_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FlavorName { get; init; }

    /// <summary> The flavor text, if any. </summary>
    [JsonPropertyName("flavor_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FlavorText { get; init; }

    /// <summary> This card's frame effects, if any. </summary>
    [JsonPropertyName("frame_effects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? FrameEffects { get; init; } // TODO: Create Frame Effects

    /// <summary> This card's frame layout </summary>
    [JsonPropertyName("frame")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public required string Frame { get; init; }

    /// <summary> True if this card’s artwork is larger than normal. </summary>
    [JsonPropertyName("full_art")]
    public bool FullArt { get; init; }

    /// <summary> A list of games that this card print is available in, paper, arena, mtgo, astral, and/or sega. </summary>
    [JsonPropertyName("games")]
    public required IReadOnlyList<string> Games { get; init; }

    /// <summary> True if this card's imagery is high resolution. </summary>
    [JsonPropertyName("highres_image")]
    public bool HighresImage { get; init; }

    /// <summary>
    /// A unique identifier for the card artwork that remains consistent across reprints. Newly spoiled
    /// cards may not have this field yet.
    /// </summary>
    [JsonPropertyName("illustration_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? IllustrationId { get; init; }

    /// <summary>
    /// A computer-readable indicator for the state of this card’s image, one of missing, placeholder, lowres, or highres_scan.
    /// </summary>
    [JsonPropertyName("image_status")]
    public required string ImageStatus { get; init; }

    /// <summary>
    /// An object listing available imagery for this card. See the Card Imagery article for more information.
    /// </summary>
    [JsonPropertyName("image_uris")]
    public Dictionary<string, Uri>? ImageUris { get; init; } // TODO: Create CardImagery Object

    /// <summary> True if this card is oversized. </summary>
    [JsonPropertyName("oversized")]
    public bool Oversized { get; init; }

    /// <summary>
    /// An object containing daily price information for this card, including usd, usd_foil, usd_etched, eur, eur_foil,
    /// eur_etched, and tix prices, as strings.
    /// </summary>
    [JsonPropertyName("prices")]
    public required Price Prices { get; init; }

    /// <summary> The localized name printed on this card, if any. </summary>
    [JsonPropertyName("printed_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedName { get; init; }

    /// <summary> The localized text printed on this card, if any. </summary>
    [JsonPropertyName("printed_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedText { get; init; }

    /// <summary> The localized type line printed on this card, if any. </summary>
    [JsonPropertyName("printed_type_line")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedTypeLine { get; init; }

    /// <summary> True if this card is a promotional print. </summary>
    [JsonPropertyName("promo")]
    public bool Promo { get; init; }

    /// <summary>  An array of strings describing what categories of promo cards this card falls into. </summary>
    [JsonPropertyName("promo_types")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? PromoTypes { get; init; }

    [JsonPropertyName("purchase_uris")]
    public Dictionary<string, Uri>? RetailerUris { get; init; }

    [JsonPropertyName("rarity")]
    public required string Rarity { get; init; }

    [JsonPropertyName("related_uris")]
    public required Dictionary<string, Uri> RelatedUris { get; init; }

    [JsonPropertyName("released_at")]
    public required string ReleasedAt { get; init; }

    [JsonPropertyName("reprint")]
    public bool Reprint { get; init; }


    [JsonPropertyName("scryfall_set_uri")]
    public required Uri ScryfallSetUri { get; init; }
    [JsonPropertyName("set_name")]
    public required string SetName { get; init; }

    [JsonPropertyName("set_search_uri")]
    public required Uri SetSearchUri { get; init; }
    [JsonPropertyName("set_type")]
    public required string SetType { get; init; }
    [JsonPropertyName("set_uri")]
    public required Uri SetUri { get; init; }

    [JsonPropertyName("set")]
    public required string Set { get; init; }
    [JsonPropertyName("set_id")]
    public required string SetId { get; init; }
    [JsonPropertyName("story_spotlight")]
    public bool StorySpotlight { get; init; }

    [JsonPropertyName("textless")]
    public bool Textless { get; init; }
    [JsonPropertyName("variation")]
    public bool Variation { get; init; }
    [JsonPropertyName("variation_of")]
    public string? VariationOf { get; init; }
    [JsonPropertyName("security_stamp")]
    public string? SecurityStamp { get; init; }

    [JsonPropertyName("watermark")]
    public string? Watermark { get; init; }
    #endregion Print Fields

    // TODO: Find an example of card with preview data and ensure it's processed correctly
    // [JsonPropertyName("preview")]
    // public Dictionary<string, string> Prewiew { get; init; }

    public override string ToString() => Name +
                (!string.IsNullOrWhiteSpace(ManaCost) ? $" ({ManaCost})" : string.Empty) +
                (!string.IsNullOrWhiteSpace(TypeLine) ? $" {TypeLine}" : string.Empty);
}
