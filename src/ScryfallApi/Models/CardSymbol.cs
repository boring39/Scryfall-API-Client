namespace ScryfallApi.Models;

public record CardSymbol : ScryfallObject
{
    /// <summary>
    /// The plaintext symbol. Often surrounded with curly braces {}. Note that not all symbols
    /// are ASCII text (for example, {∞}).
    /// </summary>
    public required string Symbol { get; init; }

    /// <summary> An alternate version of this symbol, if it is possible to write it without curly braces. </summary>
    public string? LooseVariant { get; init; }

    /// <summary>
    /// An English snippet that describes this symbol. Appropriate for use in alt text or other
    /// accessible communication formats.
    /// </summary>
    public required string English { get; init; }

    /// <summary>
    /// True if it is possible to write this symbol “backwards”. For example, the official symbol
    /// {U/P} is sometimes written as {P/U} or {P\U} in informal settings. Note that the Scryfall
    /// API never writes symbols backwards in other responses. This field is provided for informational
    /// purposes.
    /// </summary>
    public bool IsTransposable { get; init; }

    /// <summary> True if this is a mana symbol. </summary>
    public bool IsManaSymbol { get; init; }

    /// <summary>
    /// A decimal number representing this symbol’s mana value (also knowns as the converted mana cost). Note that mana
    /// symbols from funny sets can have fractional mana values.
    /// </summary>
    public decimal? ManaValue { get; init; }

    /// <summary>
    /// True if this symbol appears in a mana cost on any Magic card. For example {20} has this field
    /// set to false because {20} only appears in Oracle text, not mana costs.
    /// </summary>
    public bool AppearsInManaCosts { get; init; }

    /// <summary> True if this symbol is only used on funny cards or Un-cards. </summary>
    public bool IsFunny { get; init; }

    /// <summary>  An array of colors that this symbol represents. </summary>
    public Colors Colors { get; init; }

    /// <summary>
    /// True if the symbol is a hybrid mana symbol. Note that monocolor Phyrexian symbols aren't considered hybrid.
    /// </summary>
    public bool Hybrid { get; init; }

    /// <summary> True if the symbol is a Phyrexian mana symbol, i.e. it can be paid with 2 life. </summary>
    public bool Phyrexian { get; init; }

    /// <summary>
    /// An array of plaintext versions of this symbol that Gatherer uses on old cards to describe original printed text.
    /// For example: {W} has ["oW", "ooW"] as alternates.
    /// </summary>
    public string? GathererAlternates { get; init; }

    /// <summary> A URI to an SVG image of this symbol on Scryfall's CDNs. </summary>
    public Uri? SvgUri { get; init; }
}
