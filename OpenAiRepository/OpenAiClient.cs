using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace OpenAiRepository;

public class OpenAiClient
{
    private static HttpClient? _httpClient;
    private readonly OpenAiClientSecrets _secrets;

    public OpenAiClient(IOptions<OpenAiClientSecrets> secrets)
    {
        _secrets = secrets.Value;
        if (_httpClient is null)
        {
            InitializeClient(_secrets);
        }

        Beta = new BetaFeatures(HttpClient);
        Files = new FilesClient(HttpClient);
        VectorStores = new VectorStoresClient(HttpClient);
    }

    private static void InitializeClient(OpenAiClientSecrets secrets)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(secrets.ApiUrl!);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", secrets.ApiKey);
        _httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
    }

    public HttpClient HttpClient
    {
        get
        {
            if (_httpClient is null)
            {
                InitializeClient(_secrets);
            }

            return _httpClient!;
        }
    }

    public BetaFeatures Beta { get; init; }

    public FilesClient Files { get; init; }

    public VectorStoresClient VectorStores { get; init; }

}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenAiClient(this IServiceCollection services, Action<OpenAiClientSecrets> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddSingleton<OpenAiClient>();
        return services;
    }
}