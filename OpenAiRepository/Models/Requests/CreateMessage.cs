

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateMessage
{
    [JsonIgnore]
    [Required(AllowEmptyStrings = false)]
    public string? ThreadId { get; set; }

    [JsonPropertyName("role")]
    [Required(AllowEmptyStrings = false)]
    public string? Role { get; set; } = "user";

    [JsonPropertyName("content")]
    [Required(AllowEmptyStrings = false)]
    public string? Content { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}
