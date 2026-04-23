using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class ErrorConverter : JsonConverter<Error>
{
    public override Error? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        int? status = default;
        string? code = default;
        string? details = default;
        string? type = default;
        List<string>? warnings = default;

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

            if (propName.SequenceEqual("status"u8)) { status = reader.GetInt32(); }
            else if (propName.SequenceEqual("code"u8)) { code = reader.GetString(); }
            else if (propName.SequenceEqual("details"u8)) { details = reader.GetString(); }
            else if (propName.SequenceEqual("type"u8)) { type = reader.GetString(); }
            else if (propName.SequenceEqual("warngings"u8))
            {
                if (reader.TokenType != JsonTokenType.StartArray)
                {
                    throw new JsonException("Expected to start an array of warnings.");
                }
                warnings = [];
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType != JsonTokenType.String)
                    {
                        throw new JsonException("Invalid warning");
                    }
                    warnings.Add(reader.GetString() ?? string.Empty);
                }
            }
            else { reader.Skip(); }// Skip unknown property
        }
        // construct
        return new()
        {
            Object = "error",
            Code = code ?? throw new JsonException("Missing required code property."),
            Status = status ?? throw new JsonException("Missing required status property."),
            Warnings = warnings,
            Type = type,
            Details = details ?? throw new JsonException("Missing required details property."),

        };
    }

    public override void Write(Utf8JsonWriter writer, Error value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
