namespace ScryfallApi.Models;

public record Preview
{
    /// <summary> The date this card was previewed </summary>
    public DateOnly? PreviewedAt { get; init; }

    /// <summary> A link to the preview for this card. </summary>
    public Uri? SourceUri { get; init; }

    /// <summary> The name of the source that previewed the card. </summary>
    public string? Source { get; init; }
}
