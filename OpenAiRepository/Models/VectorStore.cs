using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

public class VectorStore
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> MetaData { get; set; } = new();
}

public class VectorStoreFile
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    [JsonPropertyName("usage_bytes")]
    public int UsageBytes { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("created_at_date")]
    public DateTime CreatedAtDate
    {
        get
        {
            DateTime dateTime = DateTime.UnixEpoch;
            dateTime = dateTime.AddSeconds(CreatedAt).ToLocalTime();
            return dateTime;
        }
    }

    [JsonPropertyName("vector_store_id")]
    public string VectorStoreId { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("chunking_strategy")]
    public ChunkingStrategy? ChunkingStrategy { get; set; }
}

public class ChunkingStrategy
{
    public virtual string Type { get; set; } = "auto";
}

public class StaticChunkingStrategy: ChunkingStrategy
{
    public override string Type { get; set; } = "static";

    public StaticChunkingStrategyOptions Static { get; set; } = new();
}

public class StaticChunkingStrategyOptions
{
    [JsonPropertyName("max_chunk_size_tokens")]
    public int MaxChunkSizeTokens { get; set; }

    [JsonPropertyName("chunk_overlap_tokens")]
    public int ChunkOverloapTokens { get; set; }
}