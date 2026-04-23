namespace ScryfallApi.Models.Benchmarks;

using System.Text.Json;
using ScryfallApi.Models.Converters;

public static class SerializerSetup
{
    public static JsonSerializerOptions Default = new();

    public static JsonSerializerOptions WithConverter = new()
    {
        Converters = { new CardObjectConverter() }
    };
}
