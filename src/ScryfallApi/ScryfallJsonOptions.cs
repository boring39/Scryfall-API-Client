using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Converters;
using ScryfallApi.Models;
using ScryfallApi.Models.Converters;

namespace ScryfallApi;

public static class ScryfallJsonOptions
{
    public static readonly JsonSerializerOptions Default = Create();

    private static JsonSerializerOptions Create()
    {
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault,
            PropertyNameCaseInsensitive = true
        };

        options.Converters.Add(new ScryfallObjectConverter());
        options.Converters.Add(new ErrorConverter());
        options.Converters.Add(new SetConverter());
        options.Converters.Add(new CardObjectConverter());
        options.Converters.Add(new RulingConverter());
        options.Converters.Add(new CardSymbolConverter());
        options.Converters.Add(new CatalogConverter());
        options.Converters.Add(new BulkDataConverter());
        options.Converters.Add(new MigrationConverter());
        options.Converters.Add(new MagicColorConverter());
        options.Converters.Add(new JsonStringEnumConverter());

        return options;
    }
}
