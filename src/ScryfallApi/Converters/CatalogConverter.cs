using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class CatalogConverter : JsonConverter<Catalog>
{
    public override Catalog? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        Uri? uri = default;
        int? totalValues = default;
        List<string>? data = default;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }


            var propName = reader.ValueSpan;
            reader.Read();

            if (propName.SequenceEqual("uri"u8)) { uri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("total_values"u8)) { totalValues = reader.GetInt32(); }
            else if (propName.SequenceEqual("data"u8))
            {
                if (reader.TokenType != JsonTokenType.StartArray)
                {
                    throw new JsonException("Expected to start an array of warnings.");
                }
                data = [];
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType != JsonTokenType.String)
                    {
                        throw new JsonException("Invalid warning");
                    }
                    data.Add(reader.GetString() ?? string.Empty);
                }
            }
            else { reader.Skip(); }// Skip unknown property
        }

        // construct
        return new()
        {
            Object = "catalog",
            Uri = uri ?? throw new JsonException("Missing uri property"),
            TotalValues = totalValues ?? throw new JsonException("Missing total_values property."),
            Data = data ?? throw new JsonException("Missing data property"),
        };
    }
    public override void Write(Utf8JsonWriter writer, Catalog value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}