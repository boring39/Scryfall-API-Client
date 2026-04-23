using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class BulkDataConverter : JsonConverter<BulkData>
{
    public override BulkData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        Guid? id = default;
        Uri? uri = default;
        string? type = default;
        string? name = default;
        string? description = default;
        Uri? downloadUri = default;
        DateTimeOffset? updatedAt = default;
        int? size = default;
        string? contentType = default;
        string? contentEncoding = default;

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

            if (propName.SequenceEqual("id"u8)) { id = reader.GetGuid(); } // TODO: TryGet pattern?
            else if (propName.SequenceEqual("uri"u8)) { uri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("type"u8)) { type = reader.GetString(); }
            else if (propName.SequenceEqual("name"u8)) { name = reader.GetString(); }
            else if (propName.SequenceEqual("description"u8)) { description = reader.GetString(); }
            else if (propName.SequenceEqual("download_uri"u8)) { downloadUri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("updated_at"u8)) { updatedAt = reader.GetDateTimeOffset(); }
            else if (propName.SequenceEqual("size"u8)) { size = reader.GetInt32(); }
            else if (propName.SequenceEqual("content_type"u8)) { contentType = reader.GetString(); }
            else if (propName.SequenceEqual("content_encoding"u8)) { contentEncoding = reader.GetString(); }
            else { reader.Skip(); }// Skip unknown property
        }

        // construct
        return new()
        {
            Object = "bulk_data",
            Id = id ?? throw new JsonException("Missing id property"),
            Uri = uri ?? throw new JsonException("Missing uri property"),
            Type = type ?? throw new JsonException("Missing type property"),
            Name = name ?? throw new JsonException("Missing name property."),
            Description = description ?? throw new JsonException("Missing description property."),
            DownloadUri = downloadUri ?? throw new JsonException("Missing download_uri property."),
            UpdatedAt = updatedAt ?? throw new JsonException("Missing updated_at property."),
            Size = size ?? throw new JsonException("Missing size property."),
            ContentType = contentType ?? throw new JsonException("Missing content_type property."),
            ContentEncoding = contentEncoding ?? throw new JsonException("Missing content_encoding property."),
        };
    }
    public override void Write(Utf8JsonWriter writer, BulkData value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}
