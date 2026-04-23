using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class RulingConverter : JsonConverter<Ruling>
{
    public override Ruling? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        Guid? oracleId = default;
        RulingSource? source = default;
        DateOnly? publishedAt = default;
        string? comment = default;

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

            ReadOnlySpan<byte> propName = reader.ValueSpan;
            reader.Read();

            if (propName.SequenceEqual("oracle_id"u8)) { oracleId = reader.GetGuid(); }
            else if (propName.SequenceEqual("source"u8)) { source = JsonSerializer.Deserialize<RulingSource>(ref reader, options); }
            else if (propName.SequenceEqual("published_at"u8)) { publishedAt = DateOnly.Parse(reader.GetString() ?? throw new JsonException("Missing published_at property")); }
            else if (propName.SequenceEqual("comment"u8)) { comment = reader.GetString(); }
            else { reader.Skip(); }// Skip unknown property
        }
        // construct
        return new()
        {
            Object = "ruling",
            OracleId = oracleId ?? throw new JsonException("Missing required oracle_id property."),
            Source = source ?? throw new JsonException("Missing required source property."),
            PublishedAt = publishedAt ?? throw new JsonException("Missing required published_at property."),
            Comment = comment ?? throw new JsonException("Missing required comment property."),

        };
    }

    public override void Write(Utf8JsonWriter writer, Ruling value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}