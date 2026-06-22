using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class CatalogTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithAllFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CatalogJson;
        ScryfallCatalog result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCatalog>(json, options);

        Assert.AreEqual("catalog", result.Object);
        Assert.AreEqual(6, result.TotalValues);
        Assert.IsNotNull(result.Data);
        Assert.HasCount(6, result.Data);
        Assert.IsTrue(result.Data.Contains("Adventure"));
        Assert.IsTrue(result.Data.Contains("Trap"));
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CatalogJson;
        ScryfallCatalog deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCatalog>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeEmptyData(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CatalogEmptyJson;
        ScryfallCatalog result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCatalog>(json, options);

        Assert.AreEqual("catalog", result.Object);
        Assert.AreEqual(0, result.TotalValues);
        Assert.IsNotNull(result.Data);
        Assert.HasCount(0, result.Data);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeEmptyAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CatalogEmptyJson;
        ScryfallCatalog deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCatalog>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
