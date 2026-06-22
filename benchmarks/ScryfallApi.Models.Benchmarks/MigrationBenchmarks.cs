using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using BenchmarkDotNet.Attributes;
using ScryfallApi.Converters;

namespace ScryfallApi.Models.Benchmarks;

public class MigrationBenchmarks
{
    public static IEnumerable<JsonSerializerOptions> Options =>
    [
        ScryfallJsonOptions.Default,
        ScryfallJsonOptions.CustomConverters,
        // new MigrationConverterFast(),
        // new MigrationConverterOnePass(),
        // new MigrationConverterOnePassU8(),
    ];

    // public static IEnumerable<byte[]> BytesGenerator => [.. _bytes!];

    // private static byte[][]? _bytes;


    [ParamsSource(nameof(Options))]
    public JsonSerializerOptions? Option;
    private string _jsonData = default!;

    // [ParamsSource(nameof(BytesGenerator))]
    // public byte[]? JsonBytes = default!;

    // [Params(1, 10, 100, 1000)]
    [Params(1_000)]
    public int Count;

    [GlobalSetup]
    public void Setup()
    {
        var single = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "Migration.Delete.Single.json"));

        // var multiple = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "Data", "Migration.Many.json"));
        // var len = multiple.Length;

        // List<byte[]> bytes = new(len);
        // foreach (var line in multiple)
        // {
        //     bytes.Add(Encoding.UTF8.GetBytes(line));
        // }
        // _bytes = [.. bytes];
        var list = Enumerable.Repeat(single, Count);
        _jsonData = $"[{string.Join(",", list)}]";

    }

    [Benchmark]
    public List<ScryfallMigration> Deserialize()
    {
        return JsonSerializer.Deserialize<List<ScryfallMigration>>(_jsonData, Option)!;
    }

    // [Benchmark]
    // public Migration DeserializeActual()
    // {
    //     return JsonSerializer.Deserialize<Migration>(JsonBytes, Option)!;
    // }

}