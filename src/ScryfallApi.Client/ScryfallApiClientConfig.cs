namespace ScryfallApi.Client;

public class ScryfallApiClientConfig
{
    private const string ScryfallApi = "https://api.scryfall.com/";
    private const int DefaultCacheDuration = 30;

    public Uri ScryfallApiBaseAddress { get; set; } = new Uri(ScryfallApi);
    public bool EnableCaching { get; set; } = true;
    public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(DefaultCacheDuration);
    public bool UseSlidingCacheExpiration { get; set; }

    internal ScryfallApiClientConfig Clone() => new()
    {
        ScryfallApiBaseAddress = ScryfallApiBaseAddress,
        CacheDuration = CacheDuration,
        EnableCaching = EnableCaching,
        UseSlidingCacheExpiration = UseSlidingCacheExpiration
    };

    public static ScryfallApiClientConfig Default => new();
}
