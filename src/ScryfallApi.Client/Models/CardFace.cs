using System.Text.Json.Serialization;

using ScryfallApi.Client.Converters;

namespace ScryfallApi.Client.Models;

public record CardFace : BaseItem
{
    /// <summary> The name of the illustrator of this card face. Newly spoiled cards may not have this field yet.</summary>
    [JsonPropertyName("artist")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Artist { get; init; }

    /// <summary> The ID of the illustrator of this card face. Newly spoiled cards may not have this field yet.</summary>
    [JsonPropertyName("artist_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid? ArtistId { get; init; }

    /// <summary> The mana value of this particular face, if the card is reversible. </summary>
    [JsonPropertyName("cmc")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal Cmc { get; init; }

    /// <summary> The colors in this face's color indicator, if any. </summary>
    [JsonPropertyName("color_indicator")]
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Colors ColorIndicator { get; init; }

    /// <summary> This face’s colors, if the game defines colors for the individual face of this card. </summary>
    [JsonPropertyName("colors")]
    [JsonConverter(typeof(MagicColorConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Colors Colors { get; init; }

    /// <summary> This face's defense, if any. </summary>
    [JsonPropertyName("defense")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Defense { get; init; }

    /// <summary> The flavor text, if any. </summary>
    [JsonPropertyName("flavor_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FlavorText { get; init; }

    /// <summary>
    /// A unique identifier for the card face artwork that remains consistent across reprints. Newly spoiled
    /// cards may not have this field yet.
    /// </summary>
    [JsonPropertyName("illustration_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid? IllustrationId { get; init; }

    /// <summary>
    /// An object providing URIs to imagery for this face, if this is a double-sided card. If this card
    /// is not double-sided, then the image_uris property will be part of the parent object instead.
    /// </summary>
    [JsonPropertyName("image_uris")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, Uri>? ImageUris { get; init; } // TODO: Create an image_uris class

    /// <summary> The layout of this card face, if the card is reversible. </summary>
    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Layout { get; init; }

    /// <summary> The face's loyalty, if any. </summary>
    [JsonPropertyName("loyalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Loyalty { get; init; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string "" if the cost is
    /// absent. Remember that per the game rules, a missing mana cost and a mana cost of {0}
    /// are different values.
    /// </summary>
    [JsonPropertyName("mana_cost")]
    public required string ManaCost { get; init; }

    /// <summary> The name of this particular face. </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary> The Oracle Id of this particular face, if the card is reversible. </summary>
    [JsonPropertyName("oracle_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid? OracleId { get; init; }

    /// <summary> The Oracle text for this face, if any. </summary>
    [JsonPropertyName("oracle_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OracleText { get; init; }

    /// <summary> This card’s power, if any. Note that some cards have powers that are not numeric, such as <b>*</b>. </summary>
    [JsonPropertyName("power")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Power { get; init; }

    /// <summary> The localized name printed on this face, if any.</summary>
    [JsonPropertyName("printed_name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedName { get; init; }

    /// <summary> The localized text printed on this face, if any.</summary>
    [JsonPropertyName("printed_text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedText { get; init; }

    /// <summary> The localized type line printed on this face, if any. </summary>
    [JsonPropertyName("printed_type_line")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PrintedTypeLine { get; init; }

    /// <summary> This card’s toughness, if any. </summary>
    [JsonPropertyName("toughness")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Toughness { get; init; }

    /// <summary> The type line of this particular face. </summary>
    [JsonPropertyName("type_line")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TypeLine { get; init; }

    /// <summary> The watermark on this particular card face, if any. </summary>
    [JsonPropertyName("watermark")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Watermark { get; init; }
}
