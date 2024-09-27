using OpenAiRepository.Models.Requests;
using Repository.OpenAi.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace OpenAiRepository;

public class RunsClient
{
    private readonly HttpClient _httpClient;

    public RunsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Run?> Retrieve(string threadId, string runId)
    {
        var stringResponse = await _httpClient.GetStringAsync($"threads/{threadId}/runs/{runId}");
        Console.WriteLine(stringResponse);
        var response = JsonSerializer.Deserialize<Run>(stringResponse);
        return response;
    }

    public async Task<Run> Create(CreateRun createRun)
    {
        var response = await _httpClient.PostAsJsonAsync($"threads/{createRun.ThreadId}/runs", createRun);
        response.EnsureSuccessStatusCode();
        Run? run = await response.Content.ReadFromJsonAsync<Run>();
        if (run is null || string.IsNullOrEmpty(run.Id))
        {
            throw new InvalidOperationException("Failed to create run");
        }
        return run;
    }

}
