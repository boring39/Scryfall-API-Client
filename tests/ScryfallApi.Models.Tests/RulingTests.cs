using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class RulingTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithAllFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.RulingJson;
        ScryfallRuling result = SerializationTestHelper.DeserializeAndAssertType<ScryfallRuling>(json, options);

        Assert.AreEqual("ruling", result.Object);
        Assert.AreEqual("afa49a09-146f-4439-850e-dd1938c93cef", result.OracleId.ToString());
        Assert.AreEqual(RulingSource.Scryfall, result.Source); //"scryfall", result.Source);
        Assert.AreEqual(new DateOnly(2015, 1, 19), result.PublishedAt);
        Assert.Contains("Derevi", result.Comment);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.RulingJson;
        ScryfallRuling deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallRuling>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
