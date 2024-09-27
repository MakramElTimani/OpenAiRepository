
using OpenAiRepository.Models.Requests;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

public class Assistant : CreateAssistant
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
}
