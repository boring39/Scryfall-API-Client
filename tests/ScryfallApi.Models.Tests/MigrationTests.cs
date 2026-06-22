using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class MigrationTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeDeleteMigrationPolymorphic(JsonSerializerOptions options)
    {
        string json = TestDataProvider.DeleteMigrationJson;
        ScryfallMigration result = SerializationTestHelper.DeserializeAndAssertType<ScryfallMigration>(json, options);

        Assert.AreEqual("migration", result.Object);
        Assert.AreEqual(MigrationStrategy.Delete, result.MigrationStrategy); //"delete", result.MigrationStrategy);
        Assert.AreEqual("b747eb29-da49-4feb-a651-9b83d43acc91", result.OldScryfallId.ToString());
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeDeleteMigrationAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.DeleteMigrationJson;
        ScryfallMigration deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallMigration>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeMergeMigrationPolymorphic(JsonSerializerOptions options)
    {
        string json = TestDataProvider.MergeMigrationJson;
        ScryfallMigration result = SerializationTestHelper.DeserializeAndAssertType<ScryfallMigration>(json, options);
        ScryfallMigration migration = Assert.IsInstanceOfType<ScryfallMigration>(result);

        Assert.AreEqual("migration", migration.Object);
        Assert.AreEqual(MigrationStrategy.Merge, migration.MigrationStrategy); //"merge", result.MigrationStrategy);
        Assert.AreEqual("89d5d2b5-3769-4341-b84e-03771dbb7491", migration.OldScryfallId.ToString());
        Assert.AreEqual("2b73d294-6ab1-4051-9b0f-d8e335d37674", migration.NewScryfallId.ToString());
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeMergeMigrationAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.MergeMigrationJson;
        ScryfallMigration deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallMigration>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
