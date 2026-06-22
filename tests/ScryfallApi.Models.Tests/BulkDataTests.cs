using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class BulkDataTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithAllFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.BulkDataJson;
        ScryfallBulkData result = SerializationTestHelper.DeserializeAndAssertType<ScryfallBulkData>(json, options);

        Assert.AreEqual("bulk_data", result.Object);
        Assert.AreEqual("27bf3214-1271-490b-bdfe-c0be6c23d02e", result.Id.ToString());
        Assert.AreEqual("oracle_cards", result.Type);
        Assert.AreEqual("Oracle Cards", result.Name);
        Assert.AreEqual(171871736, result.Size);
        Assert.AreEqual("application/json", result.ContentType);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.BulkDataJson;
        ScryfallBulkData deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallBulkData>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}