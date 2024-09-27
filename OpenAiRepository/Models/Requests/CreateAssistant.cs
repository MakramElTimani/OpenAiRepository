using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateAssistant
{
    [JsonPropertyName("model")]
    [Required(AllowEmptyStrings = false)]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("tools")]
    public AssistantTool[] Tools { get; set; } = Array.Empty<AssistantTool>();

    [JsonPropertyName("tool_resources")]
    public AssistantToolResource? ToolResources { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();

    /// <summary>
    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
    /// </summary>
    [JsonPropertyName("temperature")]
    public float? Temperature { get; set; } = 1.0f;

    /// <summary>
    /// <list type="bullet">
    /// <item>Optional</item>
    /// <item>Setting to { "type": "json_object" } enables JSON mode, which guarantees the message the model generates is valid JSON.</item>
    /// <item>Important: when using JSON mode, you must also instruct the model to produce JSON yourself via a system or user message. Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit, resulting in a long-running and seemingly "stuck" request. Also note that the message content may be partially cut off if finish_reason="length", which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.</item>
    /// </summary>
    [JsonPropertyName("response_format")]
    public string? ResponseFormat { get; set; }
}

public class ResponseFormat
{
    /// <summary>
    /// Possible values: json_object, text
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}