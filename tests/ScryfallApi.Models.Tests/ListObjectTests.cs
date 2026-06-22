using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class ListObjectTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeListOfSets(JsonSerializerOptions options)
    {
        string json = TestDataProvider.ListOfSetsJson;
        ScryfallList<ScryfallSet>? result = JsonSerializer.Deserialize<ScryfallList<ScryfallSet>>(json, options);

        Assert.IsNotNull(result);
        Assert.AreEqual("list", result.Object);
        Assert.IsFalse(result.HasMore);
        Assert.IsNotNull(result.Data);
        Assert.HasCount(3, result.Data);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeListOfSetsAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.ListOfSetsJson;
        ScryfallList<ScryfallSet>? deserialized = JsonSerializer.Deserialize<ScryfallList<ScryfallSet>>(originalJson, options);
        ScryfallList<ScryfallSet> scryfallSets = Assert.IsInstanceOfType<ScryfallList<ScryfallSet>>(deserialized);
        string reserialized = SerializationTestHelper.SerializeObject(scryfallSets, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeListOfCards(JsonSerializerOptions options)
    {
        string json = TestDataProvider.ListOfCardsJson;
        ScryfallList<ScryfallCard>? result = JsonSerializer.Deserialize<ScryfallList<ScryfallCard>>(json, options);

        Assert.IsNotNull(result);
        Assert.AreEqual("list", result.Object);
        Assert.IsFalse(result.HasMore);
        Assert.IsNotNull(result.Data);
        Assert.IsNotEmpty(result.Data);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeListOfCardsAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.ListOfCardsJson;
        ScryfallList<ScryfallCard>? deserialized = JsonSerializer.Deserialize<ScryfallList<ScryfallCard>>(originalJson, options);
        ScryfallList<ScryfallCard> scryfallCards = Assert.IsInstanceOfType<ScryfallList<ScryfallCard>>(deserialized);
        string reserialized = SerializationTestHelper.SerializeObject(scryfallCards, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
