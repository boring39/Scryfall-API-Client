using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using ScryfallApi.Models;
using ScryfallApi.Models.Converters;

namespace ScryfallApi.Models.Benchmarks;

public class CardBenchmarks
{
    private string _single = default!;
    private string _multi = default!;

    private JsonSerializerOptions _default = default!;
    private JsonSerializerOptions _withConverter = default!;

    [GlobalSetup]
    public void Setup()
    {
        TestData.Load();

        _single = TestData.SingleCardJson;
        _multi = TestData.MultiCardJson;

        _default = SerializerSetup.Default;
        _withConverter = SerializerSetup.WithConverter;
    }

    // =========================
    // SINGLE CARD
    // =========================

    [Benchmark(Baseline = true)]
    public CardFaceObject Deserialize_Single_Baseline()
    {
        return JsonSerializer.Deserialize<CardFaceObject>(_single, _default)!;
    }

    [Benchmark]
    public CardCoreObject Deserialize_Single_WithConverter()
    {
        return JsonSerializer.Deserialize<CardCoreObject>(_single, _withConverter)!;
    }

    // =========================
    // MULTI CARD (100)
    // =========================

    [Benchmark]
    public List<CardFaceObject> Deserialize_List_Baseline()
    {
        return JsonSerializer.Deserialize<List<CardFaceObject>>(_multi, _default)!;
    }

    [Benchmark]
    public List<CardCoreObject> Deserialize_List_WithConverter()
    {
        return JsonSerializer.Deserialize<List<CardCoreObject>>(_multi, _withConverter)!;
    }
}


public class LayoutDispatchBenchmarks
{
    private JsonElement _root;

    [GlobalSetup]
    public void Setup()
    {
        var doc = JsonDocument.Parse(TestData.SingleCardJson);
        _root = doc.RootElement;
    }

    [Benchmark]
    public string Extract_Layout()
    {
        return _root.GetProperty("layout").GetString()!;
    }

    [Benchmark]
    public bool Compare_Layout_String()
    {
        var layout = _root.GetProperty("layout").GetString();
        return layout == "normal";
    }
}

[MemoryDiagnoser]
public class JsonDocumentBenchmarks
{
    private string _json = default!;

    [GlobalSetup]
    public void Setup()
    {
        _json = TestData.SingleCardJson;
    }

    [Benchmark]
    public JsonDocument Parse_Document()
    {
        return JsonDocument.Parse(_json);
    }

    [Benchmark]
    public string Get_RawText()
    {
        using var doc = JsonDocument.Parse(_json);
        return doc.RootElement.GetRawText();
    }
}

public class CardFaceBenchmarks
{
    private string _json = default!;
    private JsonSerializerOptions _options = default!;

    [GlobalSetup]
    public void Setup()
    {
        _json = TestData.SingleCardJson;
        _options = SerializerSetup.WithConverter;
    }

    [Benchmark]
    public CardCoreObject Deserialize_WithFaces()
    {
        return JsonSerializer.Deserialize<CardCoreObject>(_json, _options)!;
    }
}

public class ScalingBenchmarks
{
    private string _bulk = default!;
    private JsonSerializerOptions _options = default!;

    [Params(1, 10, 100, 1000)]
    public int Count;

    [GlobalSetup]
    public void Setup()
    {
        var single = File.ReadAllText("Data/single.json");

        var list = Enumerable.Repeat(single, Count);
        _bulk = $"[{string.Join(",", list)}]";

        _options = SerializerSetup.WithConverter;
    }

    [Benchmark]
    public List<CardCoreObject> Deserialize_Scaling()
    {
        return JsonSerializer.Deserialize<List<CardCoreObject>>(_bulk, _options)!;
    }
}

public class MigrationBenchmarks
{
    public static IEnumerable<JsonConverter> Converters =>
    [
        new MigrationConverter(),
        new MigrationConverterFast(),
        new MigrationConverterOnePass(),
        new MigrationConverterOnePassU8(),
    ];

    [ParamsSource(nameof(Converters))]
    public JsonConverter? Converter;
    private string _jsonData = default!;

    [Params(1, 10, 100, 1000)]
    public int Count;

    [GlobalSetup]
    public void Setup()
    {
        var single = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "Migration.Delete.Single.json"));

        var list = Enumerable.Repeat(single, Count);
        _jsonData = $"[{string.Join(",", list)}]";

    }

    [Benchmark]
    public List<Migration> Deserialize()
    {
        JsonSerializerOptions options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault,
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(Converter!);
        return JsonSerializer.Deserialize<List<Migration>>(_jsonData, options)!;
    }

}