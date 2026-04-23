using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class MigrationConverter : JsonConverter<Migration>
{
    public override Migration? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        Uri? uri = null;
        Guid? id = null;
        DateOnly? performedAt = null;
        MigrationStrategy? strategy = null;
        Guid? oldId = null;
        Guid? newId = null;
        string? note = null;
        JsonElement? metadata = null;

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

            if (propName.SequenceEqual("uri"u8))
            {
                uri = new Uri(reader.GetString() ?? throw new JsonException("Missing uri"));
            }
            else if (propName.SequenceEqual("id"u8))
            {
                id = reader.GetGuid(); // TODO: TryGet pattern?
            }
            else if (propName.SequenceEqual("performed_at"u8))
            {
                performedAt = DateOnly.Parse(reader.GetString()!); // TODO: null handling
            }
            else if (propName.SequenceEqual("migration_strategy"u8))
            {
                strategy = JsonSerializer.Deserialize<MigrationStrategy>(ref reader, options);
            }
            else if (propName.SequenceEqual("old_scryfall_id"u8))
            {
                oldId = reader.GetGuid();
            }
            else if (propName.SequenceEqual("new_scryfall_id"u8))
            {
                newId = reader.TokenType == JsonTokenType.Null
                    ? null
                    : reader.GetGuid();
            }
            else if (propName.SequenceEqual("note"u8))
            {
                note = reader.TokenType == JsonTokenType.Null
                    ? null
                    : reader.GetString();
            }
            else if (propName.SequenceEqual("metadata"u8))
            {
                // unavoidable alloc, but only when present
                metadata = JsonElement.ParseValue(ref reader);
            }
            else
            {
                // Skip unknown property
                reader.Skip();
            }
        }
        // construct
        return strategy switch
        {
            MigrationStrategy.Merge => new MergeMigration
            {
                Object = "migration",
                Uri = uri ?? throw new JsonException("Missing uri property"),
                Id = id ?? throw new JsonException("Missing id property"),
                PerformedAt = performedAt ?? throw new JsonException("Missing performed_at property"),
                MigrationStrategy = strategy ?? throw new JsonException("Missing migration_strategy property"),
                OldScryfallId = oldId ?? throw new JsonException("Missing old_scryfall_id property"),
                NewScryfallId = newId ?? throw new JsonException("Missing new_scryfall_id property"),
                Note = note,
                Metadata = metadata
            },

            MigrationStrategy.Delete => new DeleteMigration
            {
                Object = "migration",
                Uri = uri ?? throw new JsonException("Missing uri property"),
                Id = id ?? throw new JsonException("Missing id property"),
                PerformedAt = performedAt ?? throw new JsonException("Missing performed_at property"),
                MigrationStrategy = strategy ?? throw new JsonException("Missing migration_strategy property"),
                OldScryfallId = oldId ?? throw new JsonException("Missing old_scryfall_id property"),
                Note = note,
                Metadata = metadata
            },

            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, Migration value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MergeMigration merge:
                JsonSerializer.Serialize(writer, merge, options);
                break;
            case DeleteMigration delete:
                JsonSerializer.Serialize(writer, delete, options);
                break;

            default:
                throw new JsonException($"Unknown migration type: {value.GetType()}");
        }
    }
}
