using ScryfallApi.Models;

namespace ScryfallApi.Client.Apis.Concrete;

///<inheritdoc cref="IBulkData"/>
internal class BulkData : IBulkData
{
    private const string BaseEndpoint = "/bulk-data";
    private static readonly Uri BaseEndpointUri = new(BaseEndpoint, UriKind.Relative);
    private readonly BaseRestService _restService;

    internal BulkData(BaseRestService restService) => _restService = restService;

    public Task<ListObject<ScryfallApi.Models.BulkData>> GetAllAsync(CancellationToken cancellationToken = default)
        => _restService.GetListAsync<ScryfallApi.Models.BulkData>(BaseEndpointUri, cancellationToken: cancellationToken);

    public IAsyncEnumerable<ScryfallApi.Models.BulkData> GetAllAsyncEnumerable(CancellationToken cancellationToken = default)
        => _restService.GetPagedAsync<ScryfallApi.Models.BulkData>(BaseEndpointUri, cancellationToken);

    public Task<ScryfallApi.Models.BulkData> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Uri uri = new($"{BaseEndpoint}/{id}", UriKind.Relative);
        return _restService.GetAsync<ScryfallApi.Models.BulkData>(uri, cancellationToken: cancellationToken);
    }

    public Task<ScryfallApi.Models.BulkData> GetByTypeAsync(BulkDataType type, CancellationToken cancellationToken = default)
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
        return _restService.GetAsync<ScryfallApi.Models.BulkData>(uri, cancellationToken: cancellationToken);
    }
}
