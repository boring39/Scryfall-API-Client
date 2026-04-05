using Microsoft.Extensions.Caching.Memory;

using ScryfallApi.Client.Apis;

namespace ScryfallApi.Client;

///<inheritdoc cref="IScryfallApiClient"/>
public class ScryfallApiClient : IScryfallApiClient
{
    private bool _disposed = false;
    private readonly BaseRestService _baseRestService;
    private readonly Lazy<ICards> _cards;
    ///<inheritdoc cref="ICards"/>
    public ICards Cards => _cards.Value;

    private readonly Lazy<ISets> _sets;
    ///<inheritdoc cref="ISets"/>
    public ISets Sets => _sets.Value;

    private readonly Lazy<ICatalogs> _catalogs;
    ///<inheritdoc cref="ICatalogs"/>
    public ICatalogs Catalogs => _catalogs.Value;

    private readonly Lazy<ISymbology> _symbology;
    ///<inheritdoc cref="ISymbology"/>
    public ISymbology Symbology => _symbology.Value;

    private readonly Lazy<IBulkData> _bulkData;
    ///<inheritdoc cref="IBulkData"/>
    public IBulkData BulkData => _bulkData.Value;


    /// <summary>
    /// Instantiate a new Scryfall API client.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="clientConfig"></param>
    /// <param name="cache"></param>
    public ScryfallApiClient(HttpClient httpClient, ScryfallApiClientConfig? clientConfig = null, IMemoryCache? cache = null)
    {
        if (clientConfig is null)
        {
            clientConfig = ScryfallApiClientConfig.Default;
            clientConfig.EnableCaching = cache is not null;
        }

        _baseRestService = new(httpClient, clientConfig, cache);
        _cards = new Lazy<ICards>(() => new Cards(_baseRestService));
        _catalogs = new Lazy<ICatalogs>(() => new Catalogs(_baseRestService));
        _sets = new Lazy<ISets>(() => new Sets(_baseRestService));
        _symbology = new Lazy<ISymbology>(() => new Symbology(_baseRestService));
        _bulkData = new Lazy<IBulkData>(() => new BulkData(_baseRestService));
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _baseRestService.Dispose();
        }

        _disposed = true;
    }
    public async ValueTask DisposeAsync()
    {
        await _baseRestService.DisposeAsync().ConfigureAwait(false);
        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }
}
