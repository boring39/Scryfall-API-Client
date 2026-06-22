using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi;

public static class ScryfallJsonOptions
{
    public static readonly JsonSerializerOptions Default = CreateDefault();
    public static readonly JsonSerializerOptions SourceGenerated = CreateSourceGenerator();

    private static JsonSerializerOptions CreateDefault()
    {
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault,
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower));

        return options;
    }
    private static JsonSerializerOptions CreateSourceGenerator()
    {
        JsonSerializerOptions options = new(Default)
        {
            TypeInfoResolver = ScryfallJsonContext.Default
        };
        return options;
    }

}

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    GenerationMode = JsonSourceGenerationMode.Default,
    WriteIndented = false)]
[JsonSerializable(typeof(ScryfallObject))]
[JsonSerializable(typeof(ScryfallError))]
[JsonSerializable(typeof(ScryfallSet))]
[JsonSerializable(typeof(ScryfallRuling))]
[JsonSerializable(typeof(ScryfallCardSymbol))]
[JsonSerializable(typeof(ManaCost))]
[JsonSerializable(typeof(ScryfallCatalog))]
[JsonSerializable(typeof(ScryfallBulkData))]
[JsonSerializable(typeof(ScryfallMigration))]
[JsonSerializable(typeof(ScryfallCard))]
[JsonSerializable(typeof(ScryfallRelatedCard))]
[JsonSerializable(typeof(ScryfallCardFace))]
[JsonSerializable(typeof(ScryfallList<ScryfallBulkData>))]
[JsonSerializable(typeof(ScryfallList<ScryfallCard>))]
[JsonSerializable(typeof(ScryfallList<ScryfallCardFace>))]
[JsonSerializable(typeof(ScryfallList<ScryfallCardSymbol>))]
[JsonSerializable(typeof(ScryfallList<ScryfallCatalog>))]
[JsonSerializable(typeof(ScryfallList<ScryfallError>))]
[JsonSerializable(typeof(ScryfallList<ManaCost>))]
[JsonSerializable(typeof(ScryfallList<ScryfallMigration>))]
[JsonSerializable(typeof(ScryfallList<ScryfallRelatedCard>))]
[JsonSerializable(typeof(ScryfallList<ScryfallRuling>))]
[JsonSerializable(typeof(ScryfallList<ScryfallSet>))]
[JsonSerializable(typeof(ScryfallList<ScryfallTag>))]
public partial class ScryfallJsonContext : JsonSerializerContext
{
}
