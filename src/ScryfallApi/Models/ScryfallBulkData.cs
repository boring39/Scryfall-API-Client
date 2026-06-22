namespace ScryfallApi.Models;

public sealed record ScryfallBulkData : ScryfallObject
{
    /// <summary>A unique ID for this bulk item.</summary>
    public Guid Id { get; init; }

    /// <summary>The Scryfall API URI for this file.</summary>
    public required Uri Uri { get; init; }

    /// <summary>A computer-readable string for the kind of bulk item.</summary>
    public required string Type { get; init; }

    /// <summary>A human-readable name for this file.</summary>
    public required string Name { get; init; }

    /// <summary>A human-readable description for this file.</summary>
    public required string Description { get; init; }

    /// <summary>The URI that hosts this bulk file for fetching.</summary>
    public required Uri DownloadUri { get; init; }

    /// <summary>The time when this file was last updated.</summary>
    public DateTimeOffset UpdatedAt { get; init; }

    /// <summary> The size of this file in integer bytes. </summary>
    public int Size { get; init; }

    /// <summary>The MIME type of this file.</summary>
    public required string ContentType { get; init; }

    /// <summary>The Content-Encoding encoding that will be used to transmit this file when you download it.</summary>
    public required string ContentEncoding { get; init; }
}