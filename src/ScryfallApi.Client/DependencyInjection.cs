using Microsoft.Extensions.DependencyInjection;

namespace ScryfallApi.Client;

public static class DependencyInjection
{
    public static IHttpClientBuilder AddScryfallApiClient(this IServiceCollection services) =>
        AddScryfallApiClient(services, ScryfallApiClientConfig.Default);

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if <paramref name="configure"/> is null.</summary>
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IHttpClientBuilder AddScryfallApiClient(this IServiceCollection services, Action<ScryfallApiClientConfig> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);
        ScryfallApiClientConfig clientConfig = ScryfallApiClientConfig.Default;
        configure(clientConfig);
        return AddScryfallApiClient(services, clientConfig);
    }

    public static IHttpClientBuilder AddScryfallApiClient(this IServiceCollection services, ScryfallApiClientConfig clientConfig)
    {
        services.AddScoped(services => clientConfig.Clone());
        IHttpClientBuilder clientBuilder = services.AddHttpClient<ScryfallApiClient>(ConfigureClient);

        return clientBuilder;

        void ConfigureClient(HttpClient client) => client.BaseAddress = clientConfig.ScryfallApiBaseAddress;
    }
}
