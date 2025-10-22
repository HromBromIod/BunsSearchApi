using System.Text.Json.Serialization;

namespace BunsSearchApi.Web.Contracts;

public class SearchBunChunkResponse
{
    [JsonPropertyName("bun_name")]
    public required string BunName { get; set; }
    [JsonPropertyName("search_parameter")]
    public required string SearchParameter { get; set; }
    [JsonPropertyName("message_text_part")]
    public string? MessageTextPart { get; set; }
    [JsonPropertyName("is_completed")]
    public required bool IsCompleted { get; set; }
}