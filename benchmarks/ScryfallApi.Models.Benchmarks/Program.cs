using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace ScryfallApi.Models.Benchmarks;

public class Program
{
    public static void Main(string[] args)
    {
        var config = new BenchmarkConfig();

        BenchmarkRunner.Run(
        [
            typeof(MigrationBenchmarks),
        // typeof(CardBenchmarks),
        // typeof(LayoutDispatchBenchmarks),
        // typeof(JsonDocumentBenchmarks),
        // typeof(CardFaceBenchmarks),
        // typeof(ScalingBenchmarks)
        ], config);
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        Job job = Job.Default
                     .WithWarmupCount(3)
                     .WithIterationCount(30);

        AddJob(job);

        AddColumnProvider(DefaultColumnProviders.Instance);
        AddExporter(MarkdownExporter.Default);
        AddDiagnoser(BenchmarkDotNet.Diagnosers.MemoryDiagnoser.Default);
        AddLogger(ConsoleLogger.Default);
        // AddDiagnoser(BenchmarkDotNet.Diagnosers.ThreadingDiagnoser.Default);
        // AddDiagnoser(BenchmarkDotNet.Diagnosers.ExceptionDiagnoser.Default);

    }
}