using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class CardSymbolTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithAllFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CardSymbolJson;
        ScryfallCardSymbol result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCardSymbol>(json, options);

        Assert.AreEqual("card_symbol", result.Object);
        Assert.AreEqual("{T}", result.Symbol);
        Assert.AreEqual("tap this permanent", result.English);
        Assert.IsFalse(result.RepresentsMana);
        Assert.IsFalse(result.Funny);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CardSymbolJson;
        ScryfallCardSymbol deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCardSymbol>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
