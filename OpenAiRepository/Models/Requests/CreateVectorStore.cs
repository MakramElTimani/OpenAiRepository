using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateVectorStore
{
    [JsonPropertyName("file_ids")]
    public string[] FileIds { get; set; } = Array.Empty<string>();

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
