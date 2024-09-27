using OpenAiRepository.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models;

/// <summary>
/// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types code_interpreter, file_search, or function.
/// </summary>
public class AssistantTool
{
    [JsonPropertyName("type")]
    [RegularExpression($"{AssistantToolType.CodeInterpreter}|{AssistantToolType.FileSearch}|{AssistantToolType.Function}")]
    public string Type { get; set; } = AssistantToolType.FileSearch;

}

/// <summary>
/// A set of resources that are used by the assistant's tools. The resources are specific to the type of tool. For example, the code_interpreter tool requires a list of file IDs, while the file_search tool requires a list of vector store IDs.
/// </summary>
public class AssistantToolResource
{
    [JsonPropertyName("file_search")]
    public AssistantToolResourceFileSearch? FileSearch { get; set; }

    [JsonPropertyName("code_interpreter")]
    public AssistantToolResourceCodeInterpreter? CodeInterpreter { get; set; }
}

public class AssistantToolResourceCodeInterpreter
{
    [JsonPropertyName("file_ids")]
    public string[] FileIds { get; set; } = Array.Empty<string>();
}

public class AssistantToolResourceFileSearch
{
    [JsonPropertyName("vector_store_ids")]
    public string[] VectorStoreIds { get; set; } = Array.Empty<string>();
}

public static class AssistantToolType
{
    public const string CodeInterpreter = "code_interpreter";
    public const string FileSearch = "file_search";
    public const string Function = "function";
}
