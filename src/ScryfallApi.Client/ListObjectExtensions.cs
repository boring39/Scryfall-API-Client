using System.Runtime.CompilerServices;

using ScryfallApi.Models;

namespace ScryfallApi.Client;

public static class ListObjectExtensions
{
    extension<TSource>(ScryfallList<TSource> source) where TSource : ScryfallObject
    {
        public async IAsyncEnumerable<TSource> AsAsyncEnumerable(Func<Uri, CancellationToken, Task<ScryfallList<TSource>>> fetchNextPage, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(source);

            ScryfallList<TSource> page = source;

            while (true)
            {
                foreach (TSource item in page.Data)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    yield return item;
                }

                if (!page.HasMore || page.NextPage is null)
                {
                    yield break;
                }

                page = await page.GetNextPageAsync(fetchNextPage, cancellationToken).ConfigureAwait(false);
            }
        }
        public IEnumerable<TSource> AsEnumerable(Func<Uri, CancellationToken, Task<ScryfallList<TSource>>> fetchNextPage, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(source);

            ScryfallList<TSource> page = source;

            while (true)
            {
                foreach (TSource item in page.Data)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    yield return item;
                }

                if (!page.HasMore || page.NextPage is null)
                {
                    yield break;
                }

                page = page.GetNextPageAsync(fetchNextPage, cancellationToken).GetAwaiter().GetResult();
            }
        }
        public Task<ScryfallList<TSource>> GetNextPageAsync(Func<Uri, CancellationToken, Task<ScryfallList<TSource>>> fetchNextPage, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(fetchNextPage, nameof(fetchNextPage));
            if (!source.HasMore || source.NextPage is null)
            {
                throw new InvalidOperationException("No next page available.");
            }


            return fetchNextPage(source.NextPage, cancellationToken);
        }


    }
}