namespace ScryfallApi.Client.Apis;

/// <summary>
/// For the vast majority of Scryfall’s database, Magic card entries are additive. We add new and upcoming cards as we
/// learn about them and obtain images.
/// In rare instances, Scryfall may discover that a card in our database does not really exist, or it has been deleted
/// from a digital game permanently. In these situations, we provide endpoints to help you reconcile downstream data
/// you may have synced or imported from Scryfall.
/// </summary>
public interface IMigrations
{

    // TODO: Impelement API
}