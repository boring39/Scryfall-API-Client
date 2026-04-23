namespace ScryfallApi.Models;

public record RelatedCardObject : ScryfallObject
{
    /// <summary> An unique ID for this card in Scryfall's database. </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// A field explaining what role this card plays in this relationship, one of token, meld_part, meld_result, or combo_piece.
    /// </summary>
    public required string Component { get; init; } // TODO: Create an enumeration and a converter for these?

    /// <summary> The name of this particular card. </summary>
    public required string Name { get; init; }

    /// <summary> The type line of this card. </summary>
    public required string TypeLine { get; init; }

    /// <summary> A URI where you can retrieve a full object describing this card on Scryfall's API. </summary>
    public required Uri Uri { get; init; }
}
