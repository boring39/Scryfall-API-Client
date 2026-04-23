using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>Bulk Data API</summary>
public interface IBulkData
{
    /// <summary>
    /// Get information on bulk data collections and download links
    /// </summary>
    /// <returns></returns>
    Task<ListObject<BulkData>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary> Stream all bulk data objects asynchronously across any paginated result pages. </summary>
    IAsyncEnumerable<BulkData> GetAllAsyncEnumerable(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given id.
    /// </summary>
    Task<BulkData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given type.
    /// </summary>
    Task<BulkData> GetByTypeAsync(BulkDataType type, CancellationToken cancellationToken = default);
}
