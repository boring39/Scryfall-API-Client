using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="ICatalogs"/>
public class Catalogs : ICatalogs
{
    private readonly BaseRestService _restService;

    internal Catalogs(BaseRestService restService)
    {
        _restService = restService;
    }

    public Task<Catalog> ListCardNames(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/card-names", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListWordBank(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/word-bank", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListCreatureTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/creature-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListPlaneswalkerTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/planeswalker-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListLandTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/land-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListSpellTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/spell-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListEnchantmentTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/enchantment-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListArtifactTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/artifact-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListPowers(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/powers", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListToughnesses(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/toughnesses", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListLoyalties(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/loyalties", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListWatermarks(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/watermarks", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListArtistNames(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/artist-names", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListSuperTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/supertypes", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListCardTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/card-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListBattleTypes(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/battle-types", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListKeywordAbilities(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/keyword-abilities", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListKeywordActions(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/keyword-actions", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListAbilityWords(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/ability-words", UriKind.Relative), cancellationToken: cancellationToken);
    public Task<Catalog> ListFlavorWords(CancellationToken cancellationToken = default)
        => _restService.GetAsync<Catalog>(new Uri("/catalog/flavor-words", UriKind.Relative), cancellationToken: cancellationToken);
}
