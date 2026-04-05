using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="ICatalogs"/>
internal class Catalogs : ICatalogs
{
    private const string CatalogEnpoint = "/catalog";
    private static readonly Uri CardNamesUri = new($"{CatalogEnpoint}/card-names", UriKind.Relative);
    private static readonly Uri WordBankUri = new($"{CatalogEnpoint}/word-bank", UriKind.Relative);
    private static readonly Uri CreatureTypesUri = new($"{CatalogEnpoint}/creature-types", UriKind.Relative);
    private static readonly Uri PlaneswalkerTypesUri = new($"{CatalogEnpoint}/planeswalker-types", UriKind.Relative);
    private static readonly Uri LandTypesUri = new($"{CatalogEnpoint}/land-types", UriKind.Relative);
    private static readonly Uri SpellTypesUri = new($"{CatalogEnpoint}/spell-types", UriKind.Relative);
    private static readonly Uri EnchantmentTypesUri = new($"{CatalogEnpoint}/enchantment-types", UriKind.Relative);
    private static readonly Uri ArtifactTypesUri = new($"{CatalogEnpoint}/artifact-types", UriKind.Relative);
    private static readonly Uri PowersUri = new($"{CatalogEnpoint}/powers", UriKind.Relative);
    private static readonly Uri ToughnessesUri = new($"{CatalogEnpoint}/toughnesses", UriKind.Relative);
    private static readonly Uri LoyaltiesUri = new($"{CatalogEnpoint}/loyalties", UriKind.Relative);
    private static readonly Uri WatermarksUri = new($"{CatalogEnpoint}/watermarks", UriKind.Relative);
    private static readonly Uri ArtistNamesUri = new($"{CatalogEnpoint}/artist-names", UriKind.Relative);
    private static readonly Uri SuperTypesUri = new($"{CatalogEnpoint}/supertypes", UriKind.Relative);
    private static readonly Uri CardTypesUri = new($"{CatalogEnpoint}/card-types", UriKind.Relative);
    private static readonly Uri BattleTypesUri = new($"{CatalogEnpoint}/battle-types", UriKind.Relative);
    private static readonly Uri KeywordAbilitiesUri = new($"{CatalogEnpoint}/keyword-abilities", UriKind.Relative);
    private static readonly Uri KeywordActionsUri = new($"{CatalogEnpoint}/keyword-actions", UriKind.Relative);
    private static readonly Uri AbilityWordsUri = new($"{CatalogEnpoint}/ability-words", UriKind.Relative);
    private static readonly Uri FlavorWordsUri = new($"{CatalogEnpoint}/flavor-words", UriKind.Relative);

    private readonly BaseRestService _restService;

    internal Catalogs(BaseRestService restService)
    {
        _restService = restService;
    }

    public Task<Catalog> GetCardNamesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(CardNamesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetWordBankAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(WordBankUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetCreatureTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(CreatureTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetPlaneswalkerTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(PlaneswalkerTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetLandTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(LandTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetSpellTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(SpellTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetEnchantmentTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(EnchantmentTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetArtifactTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(ArtifactTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetPowersAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(PowersUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetToughnessesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(ToughnessesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetLoyaltiesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(LoyaltiesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetWatermarksAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(WatermarksUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetArtistNamesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(ArtistNamesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetSuperTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(SuperTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetCardTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(CardTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetBattleTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(BattleTypesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetKeywordAbilitiesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(KeywordAbilitiesUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetKeywordActionsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(KeywordActionsUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetAbilityWordsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(AbilityWordsUri, cancellationToken: cancellationToken);
    public Task<Catalog> GetFlavorWordsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(FlavorWordsUri, cancellationToken: cancellationToken);
}
