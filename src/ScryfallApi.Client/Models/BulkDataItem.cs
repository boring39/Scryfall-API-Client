using System.Text.Json.Serialization;

namespace ScryfallApi.Client.Models;

public record BulkDataItem : BaseItem
{
    /// <summary>A unique ID for this bulk item.</summary>
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    /// <summary>The Scryfall API URI for this file.</summary>
    [JsonPropertyName("uri")]
    public required Uri Uri { get; init; }

    /// <summary>A computer-readable string for the kind of bulk item.</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>A human-readable name for this file.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>A human-readable description for this file.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>The URI that hosts this bulk file for fetching.</summary>
    [JsonPropertyName("download_uri")]
    public required Uri DownloadUri { get; init; }

    /// <summary>The time when this file was last updated.</summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset LastUpdated { get; init; }

    /// <summary> The size of this file in integer bytes. </summary>
    [JsonPropertyName("size")]
    public int Size { get; init; }

    /// <summary>The MIME type of this file.</summary>
    [JsonPropertyName("content_type")]
    public required string ContentType { get; init; }

    /// <summary>The Content-Encoding encoding that will be used to transmit this file when you download it.</summary>
    [JsonPropertyName("content_encoding")]
    public required string ContentEncoding { get; init; }
}