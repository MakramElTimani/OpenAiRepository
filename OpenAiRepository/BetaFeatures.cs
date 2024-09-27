
namespace OpenAiRepository;

public class BetaFeatures
{
    public BetaFeatures(HttpClient httpClient)
    {
        Assistants = new (httpClient);
        Threads = new (httpClient);
    }

    public AssistantsClient Assistants { get; init; }

    public ThreadsClient Threads { get; init; }

}
