using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class MagicColorConverter : JsonConverter<Colors>
{
    private static readonly ImmutableDictionary<string, Colors> FromCode = ImmutableDictionary.CreateRange(
    [
        KeyValuePair.Create("W" , Colors.White),
        KeyValuePair.Create("U" , Colors.Blue),
        KeyValuePair.Create("B" , Colors.Black),
        KeyValuePair.Create("R" , Colors.Red),
        KeyValuePair.Create("G" , Colors.Green),
        KeyValuePair.Create("C" , Colors.Colorless),
        KeyValuePair.Create("T" , Colors.Tap),
    ]);

    private static readonly ImmutableDictionary<Colors, string> ToCode = FromCode.ToImmutableDictionary(x => x.Value, x => x.Key);
    public override Colors Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected JSON array for MagicColor");
        }

        Colors result = Colors.None;

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            var token = reader.ValueSpan;
            if (token.SequenceEqual("W"u8)) { result |= Colors.White; }
            else if (token.SequenceEqual("U"u8)) { result |= Colors.Blue; }
            else if (token.SequenceEqual("B"u8)) { result |= Colors.Black; }
            else if (token.SequenceEqual("R"u8)) { result |= Colors.Red; }
            else if (token.SequenceEqual("G"u8)) { result |= Colors.Green; }
            else if (token.SequenceEqual("C"u8)) { result |= Colors.Colorless; }
            else if (token.SequenceEqual("T"u8)) { result |= Colors.Tap; }
            else { throw new JsonException($"Unknown color code '{token.ToString()}'"); }

        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, Colors value, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(writer, nameof(writer));
        writer.WriteStartArray();

        foreach (KeyValuePair<Colors, string> kvp in ToCode)
        {
            if (kvp.Key != Colors.None && value.HasFlag(kvp.Key))
            {
                writer.WriteStringValue(kvp.Value);
            }
        }
        writer.WriteEndArray();
    }
}