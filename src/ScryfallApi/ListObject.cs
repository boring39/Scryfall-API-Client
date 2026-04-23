using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ScryfallApi.Models;

public record ListObject<T> : ScryfallObject where T : ScryfallObject
{
    /// <summary> An array of the requested objects, in a specific order. </summary>
    [JsonPropertyName("data")]
    public required IReadOnlyList<T> Data { get; init; }

    /// <summary> True if this List is paginated and there is a page beyond the current page. </summary>
    [JsonPropertyName("has_more")]
    [MemberNotNullWhen(true, nameof(NextPage))]
    public bool HasMore { get; init; }

    /// <summary>
    /// If there is a page beyond the current page, this field will contain a full API URI to that
    /// page. You may submit a HTTP GET request to that URI to continue paginating forward on this List.
    /// </summary>
    [JsonPropertyName("next_page")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Uri? NextPage { get; init; }

    /// <summary>
    /// If this is a list of Card objects, this field will contain the total number of cards found
    /// across all pages.
    /// </summary>
    [JsonPropertyName("total_cards")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int? TotalCards { get; init; }

    /// <summary>
    /// An array of human-readable warnings issued when generating this list, as strings. Warnings are non-fatal issues that the API discovered with your input. In general, they indicate that the List will not contain the all of the information you requested. You should fix the warnings and re-submit your request.
    /// </summary>
    [JsonPropertyName("warnings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? Warnings { get; init; }

    public Func<Uri, CancellationToken, Task<ListObject<T>>>? FetchNextPage { get; init; }

    public Task<ListObject<T>> GetNextPageAsync(CancellationToken cancellationToken = default)
    {
        if (!HasMore || NextPage is null)
        {
            throw new InvalidOperationException("No next page available.");
        }

        if (FetchNextPage is null)
        {
            throw new InvalidOperationException("This ListObject was not configured for pagination. Fetch it through the client to enable paging.");
        }

        return FetchNextPage(NextPage, cancellationToken);
    }

    public IAsyncEnumerable<T> AsAsyncEnumerable(CancellationToken cancellationToken = default)
        => AsAsyncEnumerableCore(this, cancellationToken);

    public IEnumerable<T> AsEnumerable(CancellationToken cancellationToken = default)
        => AsEnumerableCore(this, cancellationToken);

    private static async IAsyncEnumerable<T> AsAsyncEnumerableCore(ListObject<T> firstPage, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (firstPage is null)
        {
            throw new ArgumentNullException(nameof(firstPage));
        }

        ListObject<T> page = firstPage;

        while (true)
        {
            foreach (T item in page.Data)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }

            if (!page.HasMore || page.NextPage is null)
            {
                yield break;
            }

            page = await page.GetNextPageAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private static IEnumerable<T> AsEnumerableCore(ListObject<T> firstPage, CancellationToken cancellationToken)
    {
        if (firstPage is null)
        {
            throw new ArgumentNullException(nameof(firstPage));
        }

        ListObject<T> page = firstPage;

        while (true)
        {
            foreach (T item in page.Data)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }

            if (!page.HasMore || page.NextPage is null)
            {
                yield break;
            }

            page = page.GetNextPageAsync(cancellationToken).GetAwaiter().GetResult();
        }
    }
}
