using System.Text.Json.Serialization;

namespace BunsSearchApi.Web.Contracts;

public class SearchBunResponse
{
    [JsonPropertyName("bun_name")]
    public required string BunName { get; set; }
    [JsonPropertyName("search_parameter")]
    public required string SearchParameter { get; set; }
    [JsonPropertyName("message_text")]
    public string? MessageText { get; set; }
    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }
}