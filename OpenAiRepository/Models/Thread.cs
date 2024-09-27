
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

public class Thread
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

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}
