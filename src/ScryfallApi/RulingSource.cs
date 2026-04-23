using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

[JsonConverter(typeof(JsonStringEnumConverter<RulingSource>))]
public enum RulingSource
{
    [EnumMember(Value = "wotc")]
    Wotc,
    [EnumMember(Value = "scryfall")]
    Scryfall
}