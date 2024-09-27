using OpenAiRepository.Models;
using OpenAiRepository.Models.Requests;
using System.Net.Http.Json;

namespace OpenAiRepository;

public class MessagesClient
{
    private readonly HttpClient _httpClient;
    public MessagesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Message> CreateMessage(CreateMessage request)
    {
        var response = await _httpClient.PostAsJsonAsync($"threads/{request.ThreadId}/messages", request);
        response.EnsureSuccessStatusCode();
        Message? message = await response.Content.ReadFromJsonAsync<Message>();
        if(message is null || string.IsNullOrEmpty(message.Id))
        {
            throw new InvalidOperationException("Failed to create message");
        }
        return message;
    }

    public async Task<Message?> GetMessage(string threadId, string messageId)
    {
        var response = await _httpClient.GetFromJsonAsync<Message>($"threads/{threadId}/messages/{messageId}");
        return response;
    }

    public async Task<ListResponse<Message>> List(string threadId, string? runId = null, ListRequest? request = null)
    {
        string url = $"threads/{threadId}/messages";
        if (!string.IsNullOrEmpty(runId))
        {
            url += $"?run_id={runId}";
        }
        var response = await _httpClient.GetFromJsonAsync<ListResponse<Message>>(url);
        if (response is null)
        {
            throw new InvalidOperationException("Failed to get messages");
        }
        return response;
    }
}
