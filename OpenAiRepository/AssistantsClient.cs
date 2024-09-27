
using OpenAiRepository.Models;
using OpenAiRepository.Models.Requests;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAiRepository;

 public class AssistantsClient
{
    private readonly HttpClient _httpClient;

    public AssistantsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ListResponse<Assistant>> GetAssistants(ListRequest? request = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ListResponse<Assistant>>("assistants");
        if (response is null)
        {
            throw new InvalidOperationException("Failed to get assistants");
        }
        return response;
    }

    public async Task<Assistant?> GetAssistant(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<Assistant>($"assistants/{id}");
        return response;
    }

    public async Task<Assistant> CreateAssistant(CreateAssistant request)
    {
        var response = await _httpClient.PostAsJsonAsync("assistants", request);
        response.EnsureSuccessStatusCode();
        Assistant? assistant = await response.Content.ReadFromJsonAsync<Assistant>();
        if(assistant is null)
        {
            throw new InvalidOperationException("Failed to create assistant");
        }
        return assistant;
    }

    public async Task<Assistant> ModifyAssistant(UpdateAssistant request, string assistantId)
    {
        var response = await _httpClient.PostAsJsonAsync($"assistants/{assistantId}", request, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        response.EnsureSuccessStatusCode();
        Assistant? assistant = await response.Content.ReadFromJsonAsync<Assistant>();
        if (assistant is null)
        {
            throw new InvalidOperationException("Failed to modify assistant");
        }
        return assistant;
    }

    public async Task<bool> DeleteAssistant(string id)
    {
        var response = await _httpClient.DeleteAsync($"assistants/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
}
