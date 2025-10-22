using System.Text.Json.Serialization;

namespace BunsSearchApi.Integration.OllamaAi.Contracts;

public class OllamaStreamResponse
{
    [JsonPropertyName("response")]
    public string? Response { get; set; }
    [JsonPropertyName("done")]
    public required bool Done { get; set; }
}