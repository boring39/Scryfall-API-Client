using System.Text.Json.Serialization;

namespace ScryfallApi.Client.Models;

public record Catalog : BaseItem
{
    /// <summary> A link to the current catalog on Scryfall's API. </summary>
    [JsonPropertyName("uri")]
    public required Uri Uri { get; init; }

    /// <summary> The number of items in the <see cref="Data"/>data</see> array. </summary>
    [JsonPropertyName("total_values")]
    public int TotalValues { get; init; }

    /// <summary> An array of datapoints, as strings. </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<string> Data { get; init; }
}
