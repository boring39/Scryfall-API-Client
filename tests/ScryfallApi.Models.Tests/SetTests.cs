using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class SetTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithAllFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.SetJson;
        ScryfallSet result = SerializationTestHelper.DeserializeAndAssertType<ScryfallSet>(json, options);

        Assert.AreEqual("set", result.Object);
        Assert.AreEqual("a4a0db50-8826-4e73-833c-3fd934375f96", result.Id.ToString());
        Assert.AreEqual("aer", result.Code);
        Assert.AreEqual("Aether Revolt", result.Name);
        Assert.AreEqual(new DateOnly(2017, 01, 20), result.ReleasedAt);
        Assert.AreEqual(SetType.Expansion, result.SetType); //"expansion", result.SetType);
        Assert.AreEqual(194, result.CardCount);
    }

    [TestMethod]
    [DynamicData(nameof(GetOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options, string originalJson)
    {
        ScryfallSet deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallSet>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetOptions()
    {
        IEnumerable<string> lines = TestDataProvider.SetsJson;
        IEnumerable<JsonSerializerOptions> options = TestDataProvider.TestJsonOptions;
        return options.SelectMany(option => lines.Select(line => new object[] { option, line }));
    }
    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
