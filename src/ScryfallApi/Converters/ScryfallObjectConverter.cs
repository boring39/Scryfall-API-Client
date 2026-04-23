using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class ScryfallObjectConverter : JsonConverter<ScryfallObject>
{
    public override ScryfallObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("object"u8, out var objectProp))
        {
            throw new JsonException("Missing 'object' property.");
        }

        string? type = objectProp.GetString()?.ToLowerInvariant();

        return type switch
        {
            "card" => JsonSerializer.Deserialize<CardObject>(root.GetRawText(), options),
            "list" => JsonSerializer.Deserialize<ListObject<ScryfallObject>>(root.GetRawText(), options),
            "error" => JsonSerializer.Deserialize<Error>(root.GetRawText(), options),
            "set" => JsonSerializer.Deserialize<Set>(root.GetRawText(), options),
            "ruling" => JsonSerializer.Deserialize<Ruling>(root.GetRawText(), options),
            "card_symbol" => JsonSerializer.Deserialize<CardSymbol>(root.GetRawText(), options),
            "catalog" => JsonSerializer.Deserialize<Catalog>(root.GetRawText(), options),
            "bulk_data" => JsonSerializer.Deserialize<BulkData>(root.GetRawText(), options),
            "migration" => JsonSerializer.Deserialize<Migration>(root.GetRawText(), options),
            _ => throw new JsonException("Unknown object type.")
        };
    }
    public override void Write(Utf8JsonWriter writer, ScryfallObject value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
}
