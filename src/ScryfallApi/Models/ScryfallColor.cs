global using ScryfallColors = ScryfallApi.Models.ScryfallColor[];
using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

public enum ScryfallColor
{
    [JsonStringEnumMemberName("W")]
    White,

    [JsonStringEnumMemberName("U")]
    Blue,

    [JsonStringEnumMemberName("B")]
    Black,

    [JsonStringEnumMemberName("R")]
    Red,

    [JsonStringEnumMemberName("G")]
    Green,

    [JsonStringEnumMemberName("C")]
    Colorless,

    [JsonStringEnumMemberName("T")]
    Tap, // Only exists for one un-card (Sole Performer) which producess "tap" mana
}
