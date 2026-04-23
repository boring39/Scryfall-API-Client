using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models.Converters;

internal class CardObjectConverter : JsonConverter<CardObject>
{
    public override CardObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (!root.TryGetProperty("layout"u8, out var layoutProp))
        {
            throw new JsonException("Missing 'layout' property.");
        }

        string? layout = layoutProp.GetString()?.ToLowerInvariant();

        var tgtTyp = layout switch
        {
            "normal" => typeof(CardCoreObject),
            "split" => typeof(SplitCard),
            "flip" => typeof(FlipCard),
            "transform" => typeof(TransformCard),
            "modal_dfc" => typeof(ModalDfcCard),
            "adventure" => typeof(AdventureCard),
            "prepare" => typeof(PrepareCard),
            "double_faced_token" => typeof(DoubleFacedTokenCard),
            "art_series" => typeof(ArtSeriesCard),
            "reversible_card" => typeof(ReversibleCard),
            "meld" => typeof(CardCoreObject),
            "leveler" => typeof(CardCoreObject),
            "class" => typeof(CardCoreObject),
            "case" => typeof(CardCoreObject),
            "saga" => typeof(CardCoreObject),
            "mutate" => typeof(CardCoreObject),
            "prototype" => typeof(CardCoreObject),
            "battle" => typeof(CardCoreObject),
            "planar" => typeof(CardCoreObject),
            "scheme" => typeof(CardCoreObject),
            "vanguard" => typeof(CardCoreObject),
            "token" => typeof(CardCoreObject),
            "emblem" => typeof(CardCoreObject),
            "augment" => typeof(CardCoreObject),
            "host" => typeof(CardCoreObject),
            _ => throw new JsonException("Layout property is not valid"),
        };

        JsonSerializerOptions newOptions = new(options);

        newOptions.Converters.Add(new CardFaceListConverter(layout));

        return (CardObject?)JsonSerializer.Deserialize(root.GetRawText(), tgtTyp, newOptions);
    }
    public override void Write(Utf8JsonWriter writer, CardObject value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}
