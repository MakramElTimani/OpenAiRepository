using System.Text.Json.Serialization;

namespace OpenAiRepository.Models.Requests;

public class CreateFile
{
    public FileStream? File { get; set; }

    public string FileName { get; set; } = "menu.json";

    public string Purpose { get; set; } = "assistants";
}
