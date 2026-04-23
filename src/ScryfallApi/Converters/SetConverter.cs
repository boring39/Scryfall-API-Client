using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class SetConverter : JsonConverter<Set>
{
    public override Set? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        Guid? id = default;
        string? code = default;
        string? mtgoCode = default;
        string? arenaCode = default;
        int? tcgPlayerId = default;
        string? name = default;
        SetType? setType = default;
        DateTime? releaseDate = default;
        string? blockCode = default;
        string? block = default;
        string? parentSetCode = default;
        int? cardCount = default;
        int? printedSize = default;
        bool? isDigital = default;
        bool? isFoilOnly = default;
        bool? isNonfoilOnly = default;
        Uri? scryfallUri = default;
        Uri? uri = default;
        Uri? iconSvgUri = default;
        Uri? searchUri = default;

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
            else if (propName.SequenceEqual("code"u8)) { code = reader.GetString(); }
            else if (propName.SequenceEqual("mtgo_code"u8)) { mtgoCode = reader.GetString(); }
            else if (propName.SequenceEqual("arena_code"u8)) { arenaCode = reader.GetString(); }
            else if (propName.SequenceEqual("tcgplayer_id"u8)) { tcgPlayerId = reader.GetInt32(); }
            else if (propName.SequenceEqual("name"u8)) { name = reader.GetString(); }
            else if (propName.SequenceEqual("set_type"u8)) { setType = JsonSerializer.Deserialize<SetType>(ref reader, options); }
            else if (propName.SequenceEqual("released_at"u8)) { releaseDate = reader.GetDateTime(); }
            else if (propName.SequenceEqual("block_code"u8)) { blockCode = reader.GetString(); }
            else if (propName.SequenceEqual("block"u8)) { block = reader.GetString(); }
            else if (propName.SequenceEqual("parent_set_code"u8)) { parentSetCode = reader.GetString(); }
            else if (propName.SequenceEqual("card_count"u8)) { cardCount = reader.GetInt32(); }
            else if (propName.SequenceEqual("printed_size"u8)) { printedSize = reader.GetInt32(); }
            else if (propName.SequenceEqual("digital"u8)) { isDigital = reader.GetBoolean(); }
            else if (propName.SequenceEqual("foil_only"u8)) { isFoilOnly = reader.GetBoolean(); }
            else if (propName.SequenceEqual("nonfoil_only"u8)) { isNonfoilOnly = reader.GetBoolean(); }
            else if (propName.SequenceEqual("scryfall_uri"u8)) { scryfallUri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("uri"u8)) { uri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("icon_svg_uri"u8)) { iconSvgUri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else if (propName.SequenceEqual("search_uri"u8)) { searchUri = new(reader.GetString() ?? throw new JsonException("invalid Uri")); }
            else { reader.Skip(); }// Skip unknown property
        }
        // construct

        return new()
        {
            Object = "set",
            Id = id ?? throw new JsonException("Missing id property"),
            Code = code ?? throw new JsonException("Missing code property"),
            MtgoCode = mtgoCode,
            ArenaCode = arenaCode,
            TcgPlayerId = tcgPlayerId,
            Name = name ?? throw new JsonException("Missing name property"),
            SetType = setType ?? throw new JsonException("Missing set_type property"),
            ReleaseDate = releaseDate,
            BlockCode = blockCode,
            Block = block,
            ParentSetCode = parentSetCode,
            CardCount = cardCount ?? throw new JsonException("Missing card_count property"),
            PrintedSize = printedSize,
            IsDigital = isDigital ?? throw new JsonException("Missing digital property"),
            IsFoilOnly = isFoilOnly ?? throw new JsonException("Missing foil_only property"),
            IsNonfoilOnly = isNonfoilOnly ?? throw new JsonException("Missing nonfoil_only property"),
            ScryfallUri = scryfallUri ?? throw new JsonException("Missing scryfall_uri property"),
            Uri = uri ?? throw new JsonException("Missing uri property"),
            IconSvgUri = iconSvgUri ?? throw new JsonException("Missing icon_svg_uri property"),
            SearchUri = searchUri ?? throw new JsonException("Missing search_uri property"),

        };
    }

    public override void Write(Utf8JsonWriter writer, Set value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}