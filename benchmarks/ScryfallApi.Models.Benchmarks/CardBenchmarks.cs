using System.Text.Json;
using BenchmarkDotNet.Attributes;

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
    public ScryfallCardFace Deserialize_Single_Baseline()
    {
        return JsonSerializer.Deserialize<ScryfallCardFace>(_single, _default)!;
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
    public List<ScryfallCardFace> Deserialize_List_Baseline()
    {
        return JsonSerializer.Deserialize<List<ScryfallCardFace>>(_multi, _default)!;
    }

    [Benchmark]
    public List<CardCoreObject> Deserialize_List_WithConverter()
    {
        return JsonSerializer.Deserialize<List<CardCoreObject>>(_multi, _withConverter)!;
    }
}
