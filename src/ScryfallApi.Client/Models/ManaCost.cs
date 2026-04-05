using System.Text.Json.Serialization;

using ScryfallApi.Client.Converters;

namespace ScryfallApi.Client.Models;

public record ManaCost : BaseObject
{
    /// <summary> The normalized cost, with correctly-ordered and wrapped mana symbols. </summary>
    [JsonPropertyName("cost")]
    public required string Cost { get; init; }

    /// <summary>
    /// The converted mana cost. If you submit Un-set mana symbols, this decimal could include fractional parts.
    /// </summary>
    [JsonPropertyName("cmc")]
    public decimal ConvertedManaCost { get; init; }

    /// <summary> The colors of the given cost. </summary>
    [JsonPropertyName("colors")]
    [JsonConverter(typeof(MagicColorConverter))]
    public Colors Colors { get; init; }

    /// <summary> True if the cost is colorless. </summary>
    [JsonPropertyName("colorless")]
    public bool IsColorless { get; init; }

    /// <summary> True if the cost is monocolored. </summary
    [JsonPropertyName("monocolored")]
    public bool IsMonocolored { get; init; }

    /// <summary> True if the cost is multicolored. </summary>
    [JsonPropertyName("multicolored")]
    public bool IsMulticolored { get; init; }
}
