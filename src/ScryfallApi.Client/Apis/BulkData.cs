using ScryfallApi.Client.Models;

namespace ScryfallApi.Client.Apis;

///<inheritdoc cref="IBulkData"/>
internal class BulkData : IBulkData
{
    private const string BaseEndpoint = "/bulk-data";
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);
    private readonly BaseRestService _restService;

    internal BulkData(BaseRestService restService) => _restService = restService;

    public Task<ResultList<BulkDataObject>> GetAllAsync(CancellationToken cancellationToken = default)
        => _restService.GetAsync<ResultList<BulkDataObject>>(BaseEndpointUri, false, cancellationToken);

    public Task<BulkDataObject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}", UriKind.Relative);
        return _restService.GetAsync<BulkDataObject>(uri, false, cancellationToken);
    }

    public Task<BulkDataObject> GetByTypeAsync(BulkDataType type, CancellationToken cancellationToken = default)
    {
        string endpoint = type switch
        {
            BulkDataType.OracleCards => "oracle_cards",
            BulkDataType.UniqueArtwork => "unique_artwork",
            BulkDataType.DefaultCards => "default_cards",
            BulkDataType.AllCards => "all_cards",
            BulkDataType.Rulings => "rulings",
            _ => throw new NotImplementedException()
        };

        Uri uri = new($"{BaseEndpoint}/{endpoint}", UriKind.Relative);
        return _restService.GetAsync<BulkDataObject>(uri, false, cancellationToken);
    }
}
