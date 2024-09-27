
using OpenAiRepository.Models.Requests;
using System.Net.Http.Json;
using Thread = OpenAiRepository.Models.Thread;

namespace OpenAiRepository;

public class ThreadsClient
{
    private readonly HttpClient _httpClient;

    public ThreadsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public MessagesClient Messages => new(_httpClient);

    public RunsClient Runs => new(_httpClient);

    public async Task<Thread> Create(CreateThread request)
    {
        var response = await _httpClient.PostAsJsonAsync("threads", request);
        response.EnsureSuccessStatusCode();
        Thread? thread = await response.Content.ReadFromJsonAsync<Thread>();
        if (thread is null)
        {
            throw new InvalidOperationException("Failed to create thread");
        }
        return thread;
    }

    public async Task Delete(string threadId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"threads/{threadId}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting thread");
        }
    }

    public async Task<Thread?> Get(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<Thread>($"threads/{id}");
        return response;
    }
}
