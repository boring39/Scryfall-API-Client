using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class MigrationStrategyConverter : JsonConverter<MigrationStrategy>
{
    public override MigrationStrategy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.ValueSpan;
        if (value.SequenceEqual("merge"u8))
        {
            return MigrationStrategy.Merge;
        }
        if (value.SequenceEqual("delete"u8))
        {
            return MigrationStrategy.Delete;
        }
        throw new JsonException($"Unknown migration strategy: {value.ToString()}");
    }
    public override void Write(Utf8JsonWriter writer, MigrationStrategy value, JsonSerializerOptions options)
    {
        var str = value switch
        {
            MigrationStrategy.Merge => "merge"u8,
            MigrationStrategy.Delete => "delete"u8,
            _ => throw new JsonException($"Unknown migration strategy: {value}")
        };

        writer.WriteStringValue(str);
    }
}