using System.Text.Json.Serialization;

using ScryfallApi.Client.Converters;

namespace ScryfallApi.Client.Models;

public record PricesObject(
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("eur")] decimal? Eur,
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("eur_foil")] decimal? EurFoil,
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("tix")] decimal? Tix,
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("usd")] decimal? Usd,
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("usd_etched")] decimal? UsdEtched,
    [property: JsonConverter(typeof(UsDecimalAsStringConverter))][property: JsonPropertyName("usd_foil")] decimal? UsdFoil
);
