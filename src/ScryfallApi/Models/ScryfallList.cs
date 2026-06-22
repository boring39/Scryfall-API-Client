using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

public record ScryfallList<T> : ScryfallObject where T : ScryfallObject
{
    /// <summary>
    /// If this is a list of Card objects, this field will contain the total number of cards found
    /// across all pages.
    /// </summary>
    public int? TotalCards { get; init; }

    /// <summary> True if this List is paginated and there is a page beyond the current page. </summary>
    [MemberNotNullWhen(true, nameof(NextPage))]
    public bool HasMore { get; init; }

    /// <summary>
    /// If there is a page beyond the current page, this field will contain a full API URI to that
    /// page. You may submit a HTTP GET request to that URI to continue paginating forward on this List.
    /// </summary>
    public Uri? NextPage { get; init; }

    /// <summary>
    /// An array of human-readable warnings issued when generating this list, as strings. Warnings are non-fatal issues that the API discovered with your input. In general, they indicate that the List will not contain the all of the information you requested. You should fix the warnings and re-submit your request.
    /// </summary>
    public string[]? Warnings { get; init; }

    /// <summary> An array of the requested objects, in a specific order. </summary>
    public required IReadOnlyList<T> Data { get; init; }

    [JsonIgnore]
    public Func<Uri, CancellationToken, Task<ScryfallList<T>>>? FetchNextPage { get; init; }

    // TODO: Move to extension method within the Client project
    public Task<ScryfallList<T>> GetNextPageAsync(CancellationToken cancellationToken = default)
        => !HasMore || NextPage is null
            ? throw new InvalidOperationException("No next page available.")
            : FetchNextPage is null
                ? throw new InvalidOperationException("This ListObject was not configured for pagination. Fetch it through the client to enable paging.")
                : FetchNextPage(NextPage, cancellationToken);
}
