
using OpenAiRepository.Models;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateVectorStoreFile
{
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;

    [JsonPropertyName("chunking_strategy")]
    public ChunkingStrategy? ChunkingStrategy { get; set; }
}
