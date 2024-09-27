using OpenAiRepository.Models;
using OpenAiRepository.Models.Requests;
using OpenAiRepository.Models;
using System.Net.Http.Json;

namespace OpenAiRepository;

public class VectorStoresClient
{
    private readonly HttpClient _httpClient;

    public VectorStoresClient(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<VectorStore> CreateVectorStore(CreateVectorStore request)
    {
        var response = await _httpClient.PostAsJsonAsync("vector_stores", request);
        response.EnsureSuccessStatusCode();
        VectorStore? vectorStore = await response.Content.ReadFromJsonAsync<VectorStore>();
        if (vectorStore is null)
        {
            throw new InvalidOperationException("Failed to create vector store");
        }
        return vectorStore;
    }

    public async Task<ListResponse<VectorStore>> ListVectorStores(ListRequest? request = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ListResponse<VectorStore>>("vector_stores");
        if (response is null)
        {
            throw new InvalidOperationException("Failed to get vector stores");
        }
        return response;
    }

    public async Task<bool> DeleteVectorStore(string id)
    {
        var response = await _httpClient.DeleteAsync($"vector_stores/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to delete vector store");
        }
        return true;
    }

    public async Task<ListResponse<VectorStoreFile>> LirstVectorStoreFiles(string id, ListRequest? request = null)
    {
        var response = await _httpClient.GetFromJsonAsync<ListResponse<VectorStoreFile>>($"vector_stores/{id}/files");
        if (response is null)
        {
            throw new InvalidOperationException("Failed to get vector store files");
        }
        return response;
    }

    public async Task<VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, CreateVectorStoreFile request)
    {
        var response = await _httpClient.PostAsJsonAsync($"vector_stores/{vectorStoreId}/files", request);
        response.EnsureSuccessStatusCode();
        VectorStoreFile? vectorStoreFile = await response.Content.ReadFromJsonAsync<VectorStoreFile>();
        if (vectorStoreFile is null)
        {
            throw new InvalidOperationException("Failed to create vector store file");
        }
        return vectorStoreFile;
    }

}
