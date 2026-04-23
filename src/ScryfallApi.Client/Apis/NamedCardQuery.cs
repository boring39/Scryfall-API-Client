using System.Web;

namespace ScryfallApi.Client.Apis;

public sealed class NamedCardQuery
{
    public required NamedCardQueryMode Mode { get; init; }
    public required string Name { get; init; }
    public string? Set { get; init; }

    internal string BuildQueryString()
    {
        Dictionary<string, string> param = [];
        if (Mode == NamedCardQueryMode.Exact)
        {
            param["exact"] = Name;
        }
        else
        {
            param["fuzzy"] = Name;
        }

        if (Set is not null)
        {
            param["set"] = Set;
        }
        return string.Join("&", param.Select(static kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
    }
}

public enum NamedCardQueryMode
{
    Exact,
    Fuzzy,
}