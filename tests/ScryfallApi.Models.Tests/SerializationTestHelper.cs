using System.Text.Json;

namespace ScryfallApi.Models.Tests;

/// <summary>
/// Reusable test infrastructure for serialization/deserialization testing across all models.
/// Provides semantic JSON comparison, polymorphic type deserialization, and JsonOptions parametrization.
/// </summary>
public static class SerializationTestHelper
{
    /// <summary>
    /// Deserializes JSON to a ScryfallObject and asserts it's the correct type.
    /// </summary>
    public static T DeserializeAndAssertType<T>(string json, JsonSerializerOptions options) where T : ScryfallObject
    {
        ScryfallObject? result = JsonSerializer.Deserialize<ScryfallObject>(json, options);
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(T), $"Expected type {typeof(T).Name} but got {result.GetType().Name}");
        return (T)result;
    }

    /// <summary>
    /// Serializes an object to JSON using the specified options.
    /// </summary>
    public static string SerializeObject<T>(T obj, JsonSerializerOptions options) where T : notnull => JsonSerializer.Serialize(obj, options);

    /// <summary>
    /// Asserts that two JSON strings are semantically equivalent (ignoring property order, whitespace differences).
    /// </summary>
    public static void AssertJsonEquivalent(string expectedJson, string actualJson)
    {
        using JsonDocument expectedDoc = JsonDocument.Parse(expectedJson);
        using JsonDocument actualDoc = JsonDocument.Parse(actualJson);

        AssertJsonElementEqual(expectedDoc.RootElement, actualDoc.RootElement, "$");
    }

    /// <summary>
    /// Recursively compares two JsonElements for semantic equality.
    /// Handles objects, arrays, and primitives, ignoring property order and whitespace.
    /// </summary>
    private static void AssertJsonElementEqual(JsonElement expected, JsonElement actual, string path)
    {
        if (expected.ValueKind != actual.ValueKind)
        {
            Assert.Fail($"At {path}: Expected {expected} Actual {actual} ValueKind mismatch. Expected {expected.ValueKind}, got {actual.ValueKind}");
        }

        switch (expected.ValueKind)
        {
            case JsonValueKind.Object:
                AssertJsonObjectEqual(expected, actual, path);
                break;

            case JsonValueKind.Array:
                AssertJsonArrayEqual(expected, actual, path);
                break;

            case JsonValueKind.String:
                Assert.AreEqual(expected.GetString(), actual.GetString(), $"At {path}: String value mismatch");
                break;

            case JsonValueKind.Number:
                Assert.AreEqual(expected.GetDouble(), actual.GetDouble(), 0.0001, $"At {path}: Number value mismatch");
                break;

            case JsonValueKind.True:
            case JsonValueKind.False:
                Assert.AreEqual(expected.GetBoolean(), actual.GetBoolean(), $"At {path}: Boolean value mismatch");
                break;

            case JsonValueKind.Null:
                // Both are null, which is equal
                break;
            case JsonValueKind.Undefined:
            default:
                Assert.Fail($"At {path}: Unexpected ValueKind {expected.ValueKind}");
                break;
        }
    }

    private static void AssertJsonObjectEqual(JsonElement expected, JsonElement actual, string path)
    {
        List<JsonProperty> expectedProps = [.. expected.EnumerateObject()];
        List<JsonProperty> actualProps = [.. actual.EnumerateObject()];

        HashSet<string> expectedKeys = [.. expectedProps.Select(p => p.Name)];
        HashSet<string> actualKeys = [.. actualProps.Select(p => p.Name)];

        List<string> missingKeys = [.. expectedKeys.Except(actualKeys)];
        List<string> extraKeys = [.. actualKeys.Except(expectedKeys)];

        if (missingKeys.Count > 0)
        {
            Assert.Fail($"At {path}: Missing properties: {string.Join(", ", missingKeys)}");
        }

        if (extraKeys.Count > 0)
        {
            Assert.Fail($"At {path}: Extra properties: {string.Join(", ", extraKeys)}");
        }

        foreach (JsonProperty expectedProp in expectedProps)
        {
            JsonProperty actualProp = actualProps.First(p => p.Name == expectedProp.Name);
            string childPath = $"{path}.{expectedProp.Name}";
            AssertJsonElementEqual(expectedProp.Value, actualProp.Value, childPath);
        }
    }

    private static void AssertJsonArrayEqual(JsonElement expected, JsonElement actual, string path)
    {
        int expectedCount = expected.GetArrayLength();
        int actualCount = actual.GetArrayLength();

        Assert.AreEqual(expectedCount, actualCount, $"At {path}: Array length mismatch");

        for (int i = 0; i < expectedCount; i++)
        {
            string childPath = $"{path}[{i}]";
            AssertJsonElementEqual(expected[i], actual[i], childPath);
        }
    }

}
