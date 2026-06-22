using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="ICatalogs"/>
internal sealed class Catalogs : ICatalogs
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

    public Task<ScryfallCatalog> GetCardNamesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(CardNamesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetWordBankAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(WordBankUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetCreatureTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(CreatureTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetPlaneswalkerTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(PlaneswalkerTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetLandTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(LandTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetSpellTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(SpellTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetEnchantmentTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(EnchantmentTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetArtifactTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(ArtifactTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetPowersAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(PowersUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetToughnessesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(ToughnessesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetLoyaltiesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(LoyaltiesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetWatermarksAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(WatermarksUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetArtistNamesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(ArtistNamesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetSuperTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(SuperTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetCardTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(CardTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetBattleTypesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(BattleTypesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetKeywordAbilitiesAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(KeywordAbilitiesUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetKeywordActionsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(KeywordActionsUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetAbilityWordsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(AbilityWordsUri, cancellationToken: cancellationToken);
    public Task<ScryfallCatalog> GetFlavorWordsAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ScryfallCatalog>(FlavorWordsUri, cancellationToken: cancellationToken);
}