using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>Bulk Data API</summary>
public interface IBulkData
{
    /// <summary>
    /// Get information on bulk data collections and download links
    /// </summary>
    /// <returns></returns>
    Task<ScryfallList<ScryfallBulkData>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary> Stream all bulk data objects asynchronously across any paginated result pages. </summary>
    IAsyncEnumerable<ScryfallBulkData> GetAllAsyncEnumerable(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given id.
    /// </summary>
    Task<ScryfallBulkData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given type.
    /// </summary>
    Task<ScryfallBulkData> GetByTypeAsync(BulkDataType type, CancellationToken cancellationToken = default);
}