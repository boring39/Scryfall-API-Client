using System.Collections.Frozen;

namespace ScryfallApi.Client;

public static class SetTypes
{
    private static FrozenDictionary<string, SetType> GetSetTypes() =>
        new Dictionary<string, SetType>()
        {
            { "core", new SetType("core", "A yearly Magic core set (Tenth Edition, etc)") },
            { "expansion", new SetType("expansion", "A rotational expansion set in a block (Zendikar, etc)") },
            { "masters", new SetType("masters", "A reprint set that contains no new cards (Modern Masters, etc)") },
            { "eternal", new SetType("eternal", "A set of new cards that only get added to high-power formats") },
            { "alchemy", new SetType("alchemy", "An Arena set designed for Alchemy") },
            { "masterpiece", new SetType("masterpiece", "Masterpiece Series premium foil cards") },
            { "arsenal", new SetType("arsenal", "A Commander-oriented gift set") },
            { "from_the_vault", new SetType("from_the_vault", "From the Vault gift sets") },
            { "spellbook", new SetType("spellbook", "Spellbook series gift sets") },
            { "premium_deck", new SetType("premium_deck", "Premium Deck Series decks") },
            { "duel_deck", new SetType("duel_deck", "Duel Decks") },
            { "draft_innovation", new SetType("draft_innovation", "Special draft sets, like Conspiracy and Battlebond") },
            { "treasure_chest", new SetType("treasure_chest", "Magic Online treasure chest prize sets") },
            { "commander", new SetType("commander", "Commander preconstructed decks") },
            { "planechase", new SetType("planechase", "Planechase sets") },
            { "archenemy", new SetType("archenemy", "Archenemy sets") },
            { "vanguard", new SetType("vanguard", "Vanguard card sets") },
            { "funny", new SetType("funny", "A funny un-set or set with funny promos (Unglued, Happy Holidays, etc)") },
            { "starter", new SetType("starter", "A starter/introductory set (Portal, etc)") },
            { "box", new SetType("box", "A gift box set") },
            { "promo", new SetType("promo", "A set that contains purely promotional cards") },
            { "token", new SetType("token", "A set made up of tokens and emblems.") },
            { "memorabilia", new SetType("memorabilia", "A set made up of gold-bordered, oversize, or trophy cards that are not legal") },
            { "minigame", new SetType("minigame", "A set that contains minigame card inserts from booster packs") },
        }.ToFrozenDictionary();

    private static readonly Lazy<IReadOnlyDictionary<string, SetType>> LazySetTypes =
        new(GetSetTypes);

    public static SetType Core => LazySetTypes.Value["core"];
    public static SetType Expansion => LazySetTypes.Value["expansion"];
    public static SetType Masters => LazySetTypes.Value["masters"];
    public static SetType Eternal => LazySetTypes.Value["eternal"];
    public static SetType Alchemy => LazySetTypes.Value["alchemy"];
    public static SetType Masterpiece => LazySetTypes.Value["masterpiece"];
    public static SetType Arsenal => LazySetTypes.Value["arsenal"];
    public static SetType FromTheVault => LazySetTypes.Value["from_the_vault"];
    public static SetType Spellbook => LazySetTypes.Value["spellbook"];
    public static SetType PremiumDeck => LazySetTypes.Value["premium_deck"];
    public static SetType DuelDeck => LazySetTypes.Value["duel_deck"];
    public static SetType DraftInnovation => LazySetTypes.Value["draft_innovation"];
    public static SetType TreasureChest => LazySetTypes.Value["treasure_chest"];
    public static SetType Commander => LazySetTypes.Value["commander"];
    public static SetType Planechase => LazySetTypes.Value["planechase"];
    public static SetType Archenemy => LazySetTypes.Value["archenemy"];
    public static SetType Vanguard => LazySetTypes.Value["vanguard"];
    public static SetType Funny => LazySetTypes.Value["funny"];
    public static SetType Starter => LazySetTypes.Value["starter"];
    public static SetType Box => LazySetTypes.Value["box"];
    public static SetType Promo => LazySetTypes.Value["promo"];
    public static SetType Token => LazySetTypes.Value["token"];
    public static SetType Memorabilia => LazySetTypes.Value["memorabilia"];
    public static SetType Minigame => LazySetTypes.Value["minigame"];
}

public class SetType : IEquatable<string>, IComparable, IComparable<string>
{
    protected internal SetType(string text, string description)
    {
        Text = text;
        Description = description;
    }

    public string Text { get; }
    public string Description { get; }

    public int CompareTo(string? other) => Text.CompareTo(other, StringComparison.CurrentCultureIgnoreCase);
    public int CompareTo(object? other) => CompareTo((other as SetType)?.Text);
    public bool Equals(string? other) => Text.Equals(other, StringComparison.Ordinal);
    public override string ToString() => Text;

    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || (obj is string a && Equals(a));

    public override int GetHashCode() => HashCode.Combine(Text, Description);

    public static bool operator ==(SetType left, SetType right) => left is null ? right is null : left.Equals(right);

    public static bool operator !=(SetType left, SetType right) => !(left == right);

    public static bool operator <(SetType left, SetType right) => left is null ? right is not null : left.CompareTo(right) < 0;

    public static bool operator <=(SetType left, SetType right) => left is null || left.CompareTo(right) <= 0;

    public static bool operator >(SetType left, SetType right) => left is not null && left.CompareTo(right) > 0;

    public static bool operator >=(SetType left, SetType right) => left is null ? right is null : left.CompareTo(right) >= 0;
}
