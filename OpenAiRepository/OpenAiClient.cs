using System.Net.Http.Headers;

namespace OpenAiRepository;

public class OpenAiClient
{
    private static HttpClient? _httpClient;
    private readonly OpenAiClientSecrets _secrets;

    public OpenAiClient(OpenAiClientSecrets secrets)
    {
        _secrets = secrets;
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