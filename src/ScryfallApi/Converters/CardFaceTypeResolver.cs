namespace ScryfallApi.Models.Converters;

internal static class CardFaceTypeResolver
{
    public static Type Resolve(string layout) => layout switch
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
        _ => throw new NotImplementedException(), // TODO: better handling
    };
}