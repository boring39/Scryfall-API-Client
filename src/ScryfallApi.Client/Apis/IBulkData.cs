using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

/// <summary>Bulk Data API</summary>
public interface IBulkData
{
    /// <summary>
    /// Get information on bulk data collections and download links
    /// </summary>
    /// <returns></returns>
    Task<ResultList<BulkDataObject>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given id.
    /// </summary>
    Task<BulkDataObject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single Bulk Data object with the given type.
    /// </summary>
    Task<BulkDataObject> GetByTypeAsync(BulkDataType type, CancellationToken cancellationToken = default);
}
