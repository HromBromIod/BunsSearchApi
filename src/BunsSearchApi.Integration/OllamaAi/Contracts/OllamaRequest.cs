using System.Text.Json.Serialization;

namespace BunsSearchApi.Integration.OllamaAi.Contracts;

public class OllamaRequest
{
    [JsonPropertyName("model")]
    public required string Model { get; set; }
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }
    [JsonPropertyName("stream")]
    public required bool Stream { get; set; }
}