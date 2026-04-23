using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class CardSymbolConverter : JsonConverter<CardSymbol>
{
    public override CardSymbol? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        // locals
        string? symbol = default;
        string? looseVariant = default;
        string? english = default;
        bool? transposable = default;
        bool? representsMana = default;
        decimal? manaValue = default;
        bool? appearsInManaCosts = default;
        bool? funny = default;
        Colors? colors = default;
        bool? hybrid = default;
        bool? phyrexian = default;
        string? gathererAlternates = default;
        Uri? svgUri = default;


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

            if (propName.SequenceEqual("symbol"u8)) { symbol = reader.GetString(); }
            else if (propName.SequenceEqual("loose_variant"u8)) { looseVariant = reader.GetString(); }
            else if (propName.SequenceEqual("english"u8)) { english = reader.GetString(); }
            else if (propName.SequenceEqual("transposable"u8)) { transposable = reader.GetBoolean(); }
            else if (propName.SequenceEqual("represents_mana"u8)) { representsMana = reader.GetBoolean(); }
            else if (propName.SequenceEqual("mana_value"u8)) { manaValue = reader.GetDecimal(); }
            else if (propName.SequenceEqual("appears_in_mana_costs"u8)) { appearsInManaCosts = reader.GetBoolean(); }
            else if (propName.SequenceEqual("funny"u8)) { funny = reader.GetBoolean(); }
            else if (propName.SequenceEqual("colors"u8)) { colors = JsonSerializer.Deserialize<Colors>(ref reader, options); }
            else if (propName.SequenceEqual("hybrid"u8)) { hybrid = reader.GetBoolean(); }
            else if (propName.SequenceEqual("phyrexian"u8)) { phyrexian = reader.GetBoolean(); }
            else if (propName.SequenceEqual("gatherer_alternates"u8)) { gathererAlternates = reader.GetString(); }
            else if (propName.SequenceEqual("svg_uri"u8)) { svgUri = new(reader.GetString() ?? throw new JsonException("Invalid Uri")); }
            else { reader.Skip(); }// Skip unknown property
        }

        // construct
        return new()
        {
            Object = "card_symbol",
            Symbol = symbol ?? throw new JsonException("Missing symbol property"),
            LooseVariant = looseVariant,
            English = english ?? throw new JsonException("Missing english property"),
            IsTransposable = transposable ?? throw new JsonException("Missing transposable property."),
            IsManaSymbol = representsMana ?? throw new JsonException("Missing represents_mana property."),
            ManaValue = manaValue,
            AppearsInManaCosts = appearsInManaCosts ?? throw new JsonException("Missing appears_in_mana_costs property."),
            IsFunny = funny ?? throw new JsonException("Missing funny property."),
            Colors = colors ?? throw new JsonException("Missing colors property."),
            Hybrid = hybrid ?? throw new JsonException("Missing hybrid property."),
            Phyrexian = phyrexian ?? throw new JsonException("Missing phyrexian property."),
            GathererAlternates = gathererAlternates,
            SvgUri = svgUri,
        };
    }
    public override void Write(Utf8JsonWriter writer, CardSymbol value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}