namespace ScryfallApi.Models;

public enum SetType // TODO: Decide what to do with the legacy set type info
{
    /// <summary> A yearly Magic core set (Tenth Edition, etc) </summary>
    Core,
    /// <summary> A rotational expansion set in a block (Zendikar, etc) </summary>
    Expansion,
    /// <summary> A reprint set that contains no new cards (Modern Masters, etc) </summary>
    Masters,
    /// <summary> A set of new cards that only get added to high-power formats </summary>
    Eternal,
    /// <summary> An Arena set designed for Alchemy </summary>
    Alchemy,
    /// <summary> Masterpiece Series premium foil cards </summary>
    Masterpiece,
    /// <summary> A Commander-oriented gift set </summary>
    Arsenal,
    /// <summary> From the Vault gift sets </summary>
    FromTheVault,
    /// <summary> Spellbook series gift sets </summary>
    Spellbook,
    /// <summary> Premium Deck Series decks </summary>
    PremiumDeck,
    /// <summary> Duel Decks </summary>
    DuelDeck,
    /// <summary> Special draft sets, like Conspiracy and Battlebond </summary>
    DraftInnovation,
    /// <summary> Magic Online treasure chest prize sets </summary>
    TreasureChest,
    /// <summary> Commander preconstructed decks </summary>
    Commander,
    /// <summary> Planechase sets </summary>
    Planechase,
    /// <summary> Archenemy sets </summary>
    Archenemy,
    /// <summary> Vanguard card sets </summary>
    Vanguard,
    /// <summary> A funny un-set or set with funny promos (unglued, happy holidays, etc) </summary>
    Funny,
    /// <summary> A starter/introductory set (Portal, etc) </summary>
    Starter,
    /// <summary> A gift box set </summary>
    Box,
    /// <summary> A set that contains purely promotional cards </summary>
    Promo,
    /// <summary> A set made up of tokens and emblems. </summary>
    Token,
    /// <summary> A set made up of gold-bordered, oversize, or trophy cards that are not legal </summary>
    Memorabilia,
    /// <summary> A set that contains minigame card inserts from booster packs </summary>
    Minigame
}