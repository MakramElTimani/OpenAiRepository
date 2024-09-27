
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

public class Message
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("object")]
    public string? Object { get; set; }

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

    [JsonPropertyName("thread_id")]
    public string? ThreadId { get; set; }

    [JsonPropertyName("role")]
    public string? Role { get; set; }

    [JsonPropertyName("content")]
    public MessageContent[] Content { get; set; } = Array.Empty<MessageContent>();

    [JsonPropertyName("assistant_id")]
    public string? AssistantId { get; set; }

    [JsonPropertyName("file_ids")]
    public string[] FileIds { get; set; }  = Array.Empty<string>();

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();

    [JsonPropertyName("run_id")]
    public string? RunId { get; set; }
}

public class MessageContent
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("text")]
    public MessageContentText? Text { get; set; }
}

public class MessageContentText
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
