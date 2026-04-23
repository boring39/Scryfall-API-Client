using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

public record ImageUrisObject(
    [property: JsonPropertyName("small")] Uri? Small,
    [property: JsonPropertyName("normal")] Uri? Normal,
    [property: JsonPropertyName("large")] Uri? Large,
    [property: JsonPropertyName("png")] Uri? Png,
    [property: JsonPropertyName("art_crop")] Uri? ArtCrop,
    [property: JsonPropertyName("border_crap")] Uri? BorderCrop
);