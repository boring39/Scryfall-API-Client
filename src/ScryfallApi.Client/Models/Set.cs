using System.Text.Json.Serialization;

namespace ScryfallApi.Client.Models;

public record SetObject : BaseItem
{
    /// <summary> A unique ID for this set on Scryfall that will not change. </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    /// <summary> The unique three to six-letter code for this set. </summary>
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    /// <summary> The unique code for this set on MTGO, which may differ from the regular code. </summary>
    [JsonPropertyName("mtgo_code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MtgoCode { get; init; }

    /// <summary> The unique code for this set on Arena, which may differ from the regular code. </summary>
    [JsonPropertyName("arena_code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ArenaCode { get; init; }

    /// <summary> The unique code for this set on Arena, which may differ from the regular code. </summary>
    [JsonPropertyName("tcgplayer_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int TcgPlayerId { get; init; }

    /// <summary> The English name of the set. </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary> A computer-readable classification for this set. See below. </summary>
    [JsonPropertyName("set_type")]
    public required string SetType { get; init; }

    /// <summary>
    /// The date the set was released (in GMT-8 Pacific time). Not all sets have a known release date.
    /// </summary>
    [JsonPropertyName("released_at")]
    public DateTime? ReleaseDate { get; init; }

    /// <summary> The block code for this set, if any. </summary>
    [JsonPropertyName("block_code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BlockCode { get; init; }

    /// <summary> The block or group name code for this set, if any. </summary>
    [JsonPropertyName("block")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Block { get; init; }

    /// <summary> The set code for the parent set, if any. promo and token sets often have a parent set. </summary>
    [JsonPropertyName("parent_set_code")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ParentSetCode { get; init; }

    /// <summary> The number of cards in this set. </summary>
    [JsonPropertyName("card_count")]
    public int CardCount { get; init; }

    /// <summary> The denominator for the set's printed collector numbers. </summary>
    [JsonPropertyName("printed_size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PrintedSize { get; init; }

    /// <summary> True if this set was only released on Magic Online. </summary>
    [JsonPropertyName("digital")]
    public bool IsDigital { get; init; }

    /// <summary> True if this set contains only foil cards. </summary>
    [JsonPropertyName("foil_only")]
    public bool IsFoilOnly { get; init; }

    /// <summary> True if this set contains only nonfoil cards. </summary>
    [JsonPropertyName("nonfoil_only")]
    public bool IsNonfoilOnly { get; init; }

    /// <summary> A link to this set's permapage on Scryfall's website. </summary>
    [JsonPropertyName("scryfall_uri")]
    public required Uri ScryfallUri { get; init; }

    /// <summary> A link to this set object on Sryfall's API. </summary>
    [JsonPropertyName("uri")]
    public required Uri Uri { get; init; }

    /// <summary>
    /// A URI to an SVG file for this set’s icon on Scryfall’s CDN. Hotlinking this image isn’t
    /// recommended, because it may change slightly over time. You should download it and use it
    /// locally for your particular user interface needs.
    /// </summary>
    [JsonPropertyName("icon_svg_uri")]
    public required Uri IconSvgUri { get; init; }

    /// <summary>  A Scryfall API URI that you can request to begin paginating over the cards in this set. </summary>
    [JsonPropertyName("search_uri")]
    public required Uri SearchUri { get; init; }

    public override string ToString() => $"{Name} ({Code})";
}
