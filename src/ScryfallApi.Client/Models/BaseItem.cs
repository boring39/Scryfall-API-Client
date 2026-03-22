using System.Text.Json.Serialization;

namespace ScryfallApi.Client.Models;

public record BaseItem
{
    [JsonPropertyName("object")]
    public required string ObjectType { get; init; }
}
