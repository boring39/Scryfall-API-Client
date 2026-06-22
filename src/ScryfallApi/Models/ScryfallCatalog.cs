namespace ScryfallApi.Models;

public record ScryfallCatalog : ScryfallObject
{
    /// <summary> A link to the current catalog on Scryfall's API. </summary>
    public required Uri Uri { get; init; }

    /// <summary> The number of items in the <see cref="Data"/>data</see> array. </summary>
    public required int TotalValues { get; init; }

    /// <summary> An array of datapoints, as strings. </summary>
    public required string[] Data { get; init; }
}
