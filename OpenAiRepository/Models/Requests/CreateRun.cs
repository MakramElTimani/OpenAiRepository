using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateRun
{
    [Required(AllowEmptyStrings = false)]
    [JsonIgnore]
    public string? ThreadId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [JsonPropertyName("assistant_id")]
    public string? AssistantId { get; set; }
}
