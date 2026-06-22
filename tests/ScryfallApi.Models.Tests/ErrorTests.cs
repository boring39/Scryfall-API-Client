using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class ErrorTests
{

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeAllFieldsValid(JsonSerializerOptions options)
    {
        string json = TestDataProvider.ErrorJson;
        ScryfallError result = SerializationTestHelper.DeserializeAndAssertType<ScryfallError>(json, options);

        Assert.AreEqual("error", result.Object);
        Assert.AreEqual("bad_request", result.Code);
        Assert.AreEqual(400, result.Status);
        Assert.IsNotNull(result.Warnings);
        Assert.IsNotEmpty(result.Warnings);
        Assert.AreEqual("All of your terms were ignored.", result.Details);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.ErrorJson;
        ScryfallError deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallError>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeWithMissingOptionalFields(JsonSerializerOptions options)
    {
        string json = TestDataProvider.ErrorMissingOptionalFieldsJson;
        ScryfallError result = SerializationTestHelper.DeserializeAndAssertType<ScryfallError>(json, options);

        Assert.AreEqual("error", result.Object);
        Assert.AreEqual("not_found", result.Code);
        Assert.AreEqual(404, result.Status);
        Assert.IsNull(result.Warnings);
        Assert.IsNull(result.Type);
        Assert.AreEqual("All of your terms were ignored.", result.Details);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });

}
