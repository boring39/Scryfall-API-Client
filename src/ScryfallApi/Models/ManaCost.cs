namespace ScryfallApi.Models;

public record ManaCost : ScryfallObject
{
    /// <summary> The normalized cost, with correctly-ordered and wrapped mana symbols. </summary>
    public required string Cost { get; init; }

    /// <summary>
    /// The converted mana cost. If you submit Un-set mana symbols, this decimal could include fractional parts.
    /// </summary>
    public decimal Cmc { get; init; }

    /// <summary> The colors of the given cost. </summary>
    public required ScryfallColors Colors { get; init; }

    /// <summary> True if the cost is colorless. </summary>
    public bool Colorless { get; init; }

    /// <summary> True if the cost is monocolored. </summary
    public bool Monocolored { get; init; }

    /// <summary> True if the cost is multicolored. </summary>
    public bool Multicolored { get; init; }
}
