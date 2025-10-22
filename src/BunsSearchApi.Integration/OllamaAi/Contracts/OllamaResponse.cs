using System.Text.Json.Serialization;

namespace BunsSearchApi.Integration.OllamaAi.Contracts;

public class OllamaResponse
{
    [JsonPropertyName("response")]
    public required string Response { get; set; }
    [JsonPropertyName("model")]
    public required string Model { get; set; }
    [JsonPropertyName("done")]
    public required bool Done { get; set; }
}