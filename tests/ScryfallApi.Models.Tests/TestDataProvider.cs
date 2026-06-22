using System.Text.Json;

namespace ScryfallApi.Models.Tests;

/// <summary>
/// Provides JSON test data for serialization/deserialization tests.
/// Data is loaded from files in the Data/ folder and cached for performance.
/// </summary>
public static class TestDataProvider
{
    private static readonly Dictionary<string, string> s_cache = [];
    private static readonly Dictionary<string, string[]> s_bulk_cache = [];
    private static readonly string s_dataFolderPath = GetDataFolderPath();

    private static string GetDataFolderPath()
    {
        // var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        //     ?? throw new InvalidOperationException("Could not determine assembly directory");
        // var dataPath = Path.Combine(assemblyDir, "..", "..", "..", "tests", "ScryfallApi.Client.Tests", "Data");
        string dataPath = Path.Combine(AppContext.BaseDirectory, "Data");
        return Path.GetFullPath(dataPath);
    }

    /// <summary>
    /// Loads JSON data from a file in the Data/ folder.
    /// Results are cached for performance.
    /// </summary>
    private static string LoadData(string fileName)
    {
        if (s_cache.TryGetValue(fileName, out string? cached))
        {
            return cached;
        }

        string filePath = Path.Combine(s_dataFolderPath, fileName);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Test data file not found: {filePath}");
        }

        string content = File.ReadAllText(filePath);
        s_cache[fileName] = content;
        return content;
    }
    private static IEnumerable<string> LoadDataList(string fileName)
    {
        if (s_bulk_cache.TryGetValue(fileName, out string[]? cached))
        {
            foreach (string line in cached)
            {
                yield return line;
            }
        }

        string filePath = Path.Combine(s_dataFolderPath, fileName);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Test data file not found: {filePath}");
        }

        string[] lines = File.ReadAllLines(filePath);
        s_bulk_cache[fileName] = lines;

        foreach (string line in lines)
        {
            yield return line;
        }
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestJsonOptions.Select(o => new object[] { o });

    /// <summary>
    /// Returns all JsonSerializerOptions variants to test against.
    /// Currently returns ScryfallJsonOptions.Default; future variants (HighPerformance, Streaming, etc.) added here.
    /// </summary>
    public static IEnumerable<JsonSerializerOptions> TestJsonOptions
    {
        get
        {
            yield return ScryfallJsonOptions.Default;
            // yield return ScryfallJsonOptions.Reflection;
            yield return ScryfallJsonOptions.SourceGenerated;
            // yield return ScryfallJsonOptions.CustomConverters;
            // Future variants:
            // yield return ScryfallJsonOptions.HighPerformance;
            // yield return ScryfallJsonOptions.Streaming;
            // yield return ScryfallJsonOptions.RawUTF8;
        }
    }

    // Properties for each model type - these call LoadData with the corresponding filename
    public static string ErrorJson => LoadData("error.json");
    public static string SetJson => LoadData("set.json");
    public static IEnumerable<string> SetsJson => LoadDataList("sets.json");
    public static string RulingJson => LoadData("ruling.json");
    public static string CardSymbolJson => LoadData("card-symbol.json");
    public static string CatalogJson => LoadData("catalog.json");
    public static string BulkDataJson => LoadData("bulk-data.json");
    public static string DeleteMigrationJson => LoadData("migration-delete.json");
    public static string MergeMigrationJson => LoadData("migration-merge.json");
    public static string ListOfCardsJson => LoadData("list-cards.json");
    public static string ListOfSetsJson => LoadData("list-sets.json");
    public static string CardFullJson => LoadData("card-full.json");
    public static string CardSingleSidedJson => LoadData("card-single-sided.json");
    public static string CardDoubleSidedJson => LoadData("card-double-sided.json");
    public static string CardReversibleJson => LoadData("card-reversible.json");

    // Edge case variants
    public static string CatalogEmptyJson => LoadData("catalog-empty.json");
    public static string ErrorMissingOptionalFieldsJson => LoadData("error-minimal.json");
}
