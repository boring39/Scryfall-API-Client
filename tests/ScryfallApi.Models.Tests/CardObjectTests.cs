using System.Runtime.InteropServices;
using System.Text.Json;

namespace ScryfallApi.Models.Tests;

[TestClass]
public sealed class CardObjectTests
{
    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeSingleSidedCard(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CardSingleSidedJson;
        ScryfallCard result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(json, options);

        Assert.IsNotNull(result);
        Assert.AreEqual("card", result.Object);
        Assert.IsInstanceOfType<CardCoreObject>(result);
        var result2 = (CardCoreObject)result;
        Assert.AreEqual("normal", result2.Layout);
        Assert.AreEqual("+2 Mace", result2.Name);
        Assert.AreEqual("Artifact — Equipment", result2.TypeLine);
        Assert.IsNotNull(result2.ImageUris);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeSingleSidedAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CardSingleSidedJson;
        ScryfallCard deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeFullCard(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CardFullJson;
        ScryfallCard result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(json, options);
        Assert.IsInstanceOfType<CardCoreObject>(result);
        var result2 = (CardCoreObject)result;

        Assert.IsNotNull(result);
        Assert.AreEqual("card", result2.Object);
        Assert.AreEqual("normal", result2.Layout);
        Assert.AreEqual("+2 Mace", result2.Name);
        Assert.AreEqual("Artifact — Equipment", result2.TypeLine);
        Assert.AreEqual("{1}{W}", result2.ManaCost);
        Assert.AreEqual(2.0m, result2.Cmc);
        Assert.IsNotNull(result2.Colors);
        // TODO: Assert.AreEqual(1, result2.Color);
        Assert.IsNotNull(result2.ImageUris);
        Assert.IsNotNull(result2.Legalities);
        Assert.IsNotNull(result2.Prices);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeFullAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CardFullJson;
        ScryfallCard deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeDoubleSidedCard(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CardDoubleSidedJson;
        ScryfallCard result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(json, options);
        Assert.IsInstanceOfType<MultiFaceCard<CardFaceDoubleSided>>(result);
        var result2 = (MultiFaceCard<CardFaceDoubleSided>)result;

        Assert.IsNotNull(result);
        Assert.AreEqual("card", result.Object);
        Assert.AreEqual("transform", result2.Layout);
        Assert.AreEqual("Ajani, Nacatl Pariah // Ajani, Nacatl Avenger", result2.Name);
        Assert.IsNotNull(result2.CardFaces);
        Assert.HasCount(2, result2.CardFaces);
        Assert.AreEqual("Legendary Creature — Cat Warrior", result2.CardFaces[0].TypeLine);
        Assert.AreEqual("Legendary Planeswalker — Ajani", result2.CardFaces[1].TypeLine);
        Assert.IsInstanceOfType<CardFaceDoubleSided>(result2.CardFaces[0]);
        Assert.IsInstanceOfType<CardFaceDoubleSided>(result2.CardFaces[1]);
        Assert.IsNotNull(((CardFaceDoubleSided)result2.CardFaces[0]).ImageUris);
        Assert.IsNotNull(((CardFaceDoubleSided)result2.CardFaces[1]).ImageUris);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeDoubleSidedAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CardDoubleSidedJson;
        ScryfallCard deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void DeserializeReversibleCard(JsonSerializerOptions options)
    {
        string json = TestDataProvider.CardReversibleJson;
        ScryfallCard result = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(json, options);
        Assert.IsInstanceOfType<ReversibleCard>(result);
        var result2 = (ReversibleCard)result;

        Assert.IsNotNull(result);
        Assert.AreEqual("card", result2.Object);
        Assert.AreEqual("reversible_card", result2.Layout);
        Assert.AreEqual("Ugin, Eye of the Storms // Ugin, Eye of the Storms", result2.Name);
        Assert.IsNotNull(result2.CardFaces);
        Assert.HasCount(2, result2.CardFaces);
        Assert.AreEqual("Legendary Planeswalker — Ugin", result2.CardFaces[0].TypeLine);
        Assert.AreEqual("Legendary Planeswalker — Ugin", result2.CardFaces[1].TypeLine);
        Assert.IsInstanceOfType<CardFaceReversible>(result2.CardFaces[0]);
        Assert.IsInstanceOfType<CardFaceReversible>(result2.CardFaces[1]);
        Assert.IsNotNull(((CardFaceReversible)result2.CardFaces[0]).ImageUris);
        Assert.IsNotNull(((CardFaceReversible)result2.CardFaces[1]).ImageUris);
    }

    [TestMethod]
    [DynamicData(nameof(GetJsonOptions))]
    public void SerializeReversibleAndCompare(JsonSerializerOptions options)
    {
        string originalJson = TestDataProvider.CardReversibleJson;
        ScryfallCard deserialized = SerializationTestHelper.DeserializeAndAssertType<ScryfallCard>(originalJson, options);
        string reserialized = SerializationTestHelper.SerializeObject(deserialized, options);

        SerializationTestHelper.AssertJsonEquivalent(originalJson, reserialized);
    }

    public static IEnumerable<object[]> GetJsonOptions()
        => TestDataProvider.TestJsonOptions.Select(o => new object[] { o });
}
