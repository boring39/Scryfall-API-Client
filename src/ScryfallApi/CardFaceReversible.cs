namespace ScryfallApi.Models;

/// <summary>
/// This card face is only for parent layouts of "reversible_card"
/// </summary>
public record CardFaceReversible : CardFaceDoubleSided
{
    /// <summary> The Oracle Id of this particular face, if the card is reversible. </summary>
    public Guid? OracleId { get; init; }

    /// <summary> The mana value of this particular face, if the card is reversible. </summary>
    public decimal Cmc { get; init; }

    /// <summary> The layout of this card face, if the card is reversible. </summary>
    public string? Layout { get; init; }
}
