using System.Text.Json;
using System.Text.Json.Serialization;

using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Converters;

internal class MagicColorConverter : JsonConverter<Colors>
{
    private static readonly Dictionary<string, Colors> FromCode = new()
    {
        ["W"] = Colors.White,
        ["U"] = Colors.Blue,
        ["B"] = Colors.Black,
        ["R"] = Colors.Red,
        ["G"] = Colors.Green,
        ["C"] = Colors.Colorless,
        ["T"] = Colors.Tap,
    };

    private static readonly Dictionary<Colors, string> ToCode = FromCode.ToDictionary(x => x.Value, x => x.Key);
    public override Colors Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Colors result = Colors.None;

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected JSON array for MagicColor");
        }

        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
        {
            string? token = reader.GetString();
            if (token is null || !FromCode.TryGetValue(token, out Colors color))
            {
                throw new JsonException($"Unknown color code '{token}'");
            }

            result |= color;
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