namespace ScryfallApi.Models;

public record CardFaceObject : ScryfallObject
{
    /// <summary> The name of the illustrator of this card face. Newly spoiled cards may not have this field yet.</summary>
    public string? Artist { get; init; }

    /// <summary> The ID of the illustrator of this card face. Newly spoiled cards may not have this field yet.</summary>
    public Guid? ArtistId { get; init; }

    /// <summary> The colors in this face's color indicator, if any. </summary>
    public Colors ColorIndicator { get; init; }

    /// <summary> This face’s colors, if the game defines colors for the individual face of this card. </summary>
    public Colors Colors { get; init; }

    /// <summary> This face's defense, if any. </summary>
    public string? Defense { get; init; }

    /// <summary> The flavor text, if any. </summary>
    public string? FlavorText { get; init; }

    /// <summary>
    /// A unique identifier for the card face artwork that remains consistent across reprints. Newly spoiled
    /// cards may not have this field yet.
    /// </summary>
    public Guid? IllustrationId { get; init; }

    /// <summary> The face's loyalty, if any. </summary>
    public string? Loyalty { get; init; }

    /// <summary>
    /// The mana cost for this card. This value will be any empty string "" if the cost is
    /// absent. Remember that per the game rules, a missing mana cost and a mana cost of {0}
    /// are different values.
    /// </summary>

    /// <summary> The name of this particular face. </summary>

    /// <summary> The Oracle text for this face, if any. </summary>
    public string? OracleText { get; init; }

    /// <summary> This card’s power, if any. Note that some cards have powers that are not numeric, such as <b>*</b>. </summary>
    public string? Power { get; init; }

    /// <summary> The localized name printed on this face, if any.</summary>
    public string? PrintedName { get; init; }

    /// <summary> The localized text printed on this face, if any.</summary>
    public string? PrintedText { get; init; }

    /// <summary> The localized type line printed on this face, if any. </summary>
    public string? PrintedTypeLine { get; init; }

    /// <summary> This card’s toughness, if any. </summary>
    public string? Toughness { get; init; }

    /// <summary> The type line of this particular face. </summary>
    public string? TypeLine { get; init; }

    /// <summary> The watermark on this particular card face, if any. </summary>
    public string? Watermark { get; init; }

}
