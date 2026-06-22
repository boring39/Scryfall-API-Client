using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "object",
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(ScryfallBulkData), "bulk_data")]
[JsonDerivedType(typeof(ScryfallCard), "card")]
[JsonDerivedType(typeof(ScryfallCardFace), "card_face")]
[JsonDerivedType(typeof(ScryfallCardSymbol), "card_symbol")]
[JsonDerivedType(typeof(ScryfallCatalog), "catalog")]
[JsonDerivedType(typeof(ScryfallError), "error")]
[JsonDerivedType(typeof(ScryfallList<>), "list")]
[JsonDerivedType(typeof(ManaCost), "mana_cost")]
[JsonDerivedType(typeof(ScryfallMigration), "migration")]
[JsonDerivedType(typeof(ScryfallRelatedCard), "related_card")]
[JsonDerivedType(typeof(ScryfallRuling), "ruling")]
[JsonDerivedType(typeof(ScryfallSet), "set")]
[JsonDerivedType(typeof(ScryfallTag), "tag")]
public abstract record ScryfallObject
{
    [JsonPropertyOrder(-1)]
    public required string Object { get; init; } // TODO: This should not be string but should be an enum
}
