using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models.Converters;

internal class ImageStatusConverter : JsonConverter<ImageStatus>
{
    public override ImageStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "missing" => ImageStatus.Missing,
            "placeholder" => ImageStatus.Placeholder,
            "lowres" => ImageStatus.LowRes,
            "highres_scan" => ImageStatus.HighResScan,
            _ => throw new JsonException($"Unknown Image Status: {value}")
        };
    }

    public override void Write(Utf8JsonWriter writer, ImageStatus value, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(writer, nameof(writer));
        string text = value switch
        {
            ImageStatus.Missing => "missing",
            ImageStatus.Placeholder => "placeholder",
            ImageStatus.LowRes => "lowres",
            ImageStatus.HighResScan => "highres_scan",
            _ => throw new JsonException("Unknown migration strategy"),
        };
        writer.WriteStringValue(text);
    }
}