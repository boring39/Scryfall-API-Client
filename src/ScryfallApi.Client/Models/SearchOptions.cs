using System.Text;
using System.Web;

namespace ScryfallApi.Client.Models;

public struct SearchOptions
{
    /// <summary> The order parameter determines how Scryfall should sort the returned cards. </summary>
    public enum SortOrder
    {
        /// <summary> Sort cards by name, A → Z </summary>
        Name,

        /// <summary> Sort cards by their set and collector number: AAA/#1 → ZZZ/#999 </summary>
        Set,

        /// <summary> Sort cards by their lowest known TIX price: 0.01 → highest, null last </summary>
        Tix,

        /// <summary> Sort cards by their lowest known U.S. Dollar price: 0.01 → highest, null last </summary>
        Usd,

        /// <summary> Sort cards by their lowest known Euro price: 0.01 → highest, null last </summary>
        Eur,

        /// <summary> Sort cards by their converted mana cost: 0 → highest </summary>
        Cmc,

        /// <summary> Sort cards by their power: null → highest </summary>
        Power,

        /// <summary> Sort cards by their toughness: null → highest </summary>
        Toughness,

        /// <summary> Sort cards by their rarity: Common → Mythic </summary>
        Rarity,

        /// <summary> Sort cards by their color and color identity: WUBRG → multicolor → colorless </summary>
        Color,

        /// <summary> Sort cards by their EDHREC ranking: lowest → highest </summary>
        EdhRec,

        /// <summary> Sort cards by their release date: Newest → Oldest </summary>
        Released,

        /// <summary> Sort cards by their Penny Dreadful ranking: lowest → highest </summary>
        Penny,

        /// <summary> Sort cards by their front-side artist name: A → Z </summary>
        Artist,

        /// <summary>
        /// Sort cards how podcasts review sets, usually color & CMC, lowest → highest, with Booster Fun cards at the end
        /// </summary>
        Review,
    }

    /// <summary> The unique parameter specifies if Scryfall should remove “duplicate” results in your query.  </summary>
    public enum UniqueModes
    {
        /// <summary>
        /// Removes duplicate gameplay objects (cards that share a name and have the same functionality). For example,
        /// if your search matches more than one print of Pacifism, only one copy of Pacifism will be returned.
        /// </summary>
        Cards = 0,

        /// <summary>
        /// Returns only one copy of each unique artwork for matching cards. For example, if your search matches more
        /// than one print of Pacifism, one card with each different illustration for Pacifism will be returned, but
        /// any cards that duplicate artwork already in the results will be omitted.
        /// </summary>
        Art = 1,

        /// <summary>
        /// Returns all prints for all cards matched (disables rollup). For example, if your search matches more than
        /// one print of Pacifism, all matching prints will be returned.
        /// </summary>
        Prints = 2
    }

    /// <summary> You can optionally specify a dir parameter to choose which direction the sorting should occur. </summary>
    public enum SortDirection
    {
        /// <summary> Scryfall will automatically choose the most inuitive direction to sort </summary>
        Auto = 0,

        /// <summary> Sort ascending </summary>
        Asc = 1,

        /// <summary> Sort descending </summary>
        Desc = 2
    }

    /// <summary> The direction to sort cards. </summary>
    public SortDirection Direction { get; init; }

    /// <summary>
    /// If true, extra cards (tokens, planes, etc) will be included. Equivalent to
    /// adding include:extras to the fulltext search. Defaults to false.
    /// </summary>
    public bool IncludeExtras { get; init; }

    /// <summary> If true, cards in every language supported by Scryfall will be included. Defaults to false. </summary>
    public bool IncludeMultilingual { get; init; }

    /// <summary> The strategy for omitting similar cards. </summary>
    public UniqueModes Mode { get; init; }

    /// <summary> The method to sort returned cards. </summary>
    public SortOrder Order { get; init; }

    internal readonly string BuildQueryString()
    {
        Dictionary<string, string> param = [];

        if (Mode != UniqueModes.Cards)
        {
            param["unique"] = Mode.ToString().ToLowerInvariant();
        }

        if (Order != SortOrder.Name)
        {
            param["order"] = Order.ToString().ToLowerInvariant();
        }

        if (Direction != SortDirection.Auto)
        {
            param["dir"] = Direction.ToString().ToLowerInvariant();
        }

        if (IncludeExtras)
        {
            param["include_extras"] = "true";
        }

        if (IncludeMultilingual)
        {
            param["include_multilingual"] = "true";
        }
        return string.Join("&", param.Select(static kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
    }
}
