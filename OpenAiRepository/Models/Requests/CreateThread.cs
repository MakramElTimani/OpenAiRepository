
using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests
{
    public class CreateThread
    {
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}
