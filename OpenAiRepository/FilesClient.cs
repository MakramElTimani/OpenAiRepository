
using OpenAiRepository.Models.Requests;
using OpenAiRepository.Models;
using System.Net.Http.Json;

namespace OpenAiRepository;

public class FilesClient
{
    private readonly HttpClient _httpClient;
    public FilesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OpenAiFile> CreateFile(CreateFile request)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(request.File!), "file", request.FileName);
        content.Add(new StringContent(request.Purpose), "purpose");
        HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, "files")
        {
            Content = content
        };
        //httpRequestMessage.Headers.Add("Content-Type", "multipart/form-data");
        //call the API
        var response = await _httpClient.SendAsync(httpRequestMessage);
        response.EnsureSuccessStatusCode();
        OpenAiFile? file = await response.Content.ReadFromJsonAsync<OpenAiFile>();
        if (file is null)
        {
            throw new InvalidOperationException("Failed to create File");
        }
        return file;
    }

    public async Task<OpenAiFile?> GetFile(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<OpenAiFile>($"files/{id}");
        return response;
    }

    public async Task<ListResponse<OpenAiFile>> ListFiles(ListRequest? request = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ListResponse<OpenAiFile>>("files");
        if (response is null)
        {
            throw new InvalidOperationException("Failed to get files");
        }
        return response;
    }

    public async Task<bool> DeleteFile(string id)
    {
        var response = await _httpClient.DeleteAsync($"files/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to delete file");
        }
        return true;
    }

    public async Task<string?> ReadFileContent(string id)
    {
        var response = await _httpClient.GetAsync($"files/{id}/content");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to read file content");
        }
        return await response.Content.ReadAsStringAsync();
    }

}
