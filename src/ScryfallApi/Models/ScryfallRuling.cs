namespace ScryfallApi.Models;

public record ScryfallRuling : ScryfallObject
{
    /// <summary> The Oracle ID of the card this ruling is associated with. </summary>
    public required Guid OracleId { get; init; }

    /// <summary>
    /// A computer-readable string indicating which company produced this ruling, either wotc or scryfall.
    /// </summary>
    public required RulingSource Source { get; init; }

    /// <summary> The date when the ruling or note was published. </summary>
    public required DateOnly PublishedAt { get; init; }

    /// <summary> The text of the ruling </summary>
    public required string Comment { get; init; }


}