using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

public class OpenAiFile
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("bytes")]
    public int Bytes { get; set; }

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = string.Empty;

    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }
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
