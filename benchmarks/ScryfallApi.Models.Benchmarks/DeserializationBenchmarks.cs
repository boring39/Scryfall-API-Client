using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using ScryfallApi.Converters;

namespace ScryfallApi.Models.Benchmarks;


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
