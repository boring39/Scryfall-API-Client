using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

public enum Frame
{
    [JsonStringEnumMemberName("1993")]
    Alpha,

    [JsonStringEnumMemberName("1997")]
    Mirage,

    [JsonStringEnumMemberName("2003")]
    Modern,

    [JsonStringEnumMemberName("2015")]
    M15,

    Future
}
