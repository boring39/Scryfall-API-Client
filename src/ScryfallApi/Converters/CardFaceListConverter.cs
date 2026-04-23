using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models.Converters;

internal class CardFaceListConverter(string layout) : JsonConverter<List<CardFaceObject>>
{
    private readonly string _layout = layout;
    private static Type Resolve(string layout) => layout switch
    {

        "split" or "flip" or "adventure" or "prepare"
            => typeof(CardFaceObject),

        "transform" or "modal_dfc" or "double_faced_token" or "art_series"
            => typeof(CardFaceDoubleSided),

        "reversible_card"
            => typeof(ReversibleCard),

        "normal" or "meld" or "leveler" or "class" or
        "case" or "saga" or "mutate" or "prototype" or
        "battle" or "planar" or "scheme" or "vanguard" or
        "token" or "emblem" or "augment" or "host"
            => typeof(CardCoreObject),
        _ => throw new NotImplementedException(), // TODO: handle better
    };

    public override List<CardFaceObject>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Type facetype = Resolve(_layout);

        using JsonDocument doc = JsonDocument.ParseValue(ref reader);

        List<CardFaceObject> result = [];

        foreach (var element in doc.RootElement.EnumerateArray())
        {
            var face = (CardFaceObject?)JsonSerializer.Deserialize(element.GetRawText(), facetype, options);

            if (face is not null)
            {
                result.Add(face);
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, List<CardFaceObject> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}
