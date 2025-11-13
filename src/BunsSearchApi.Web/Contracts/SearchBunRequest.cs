using System.Text.Json.Serialization;

namespace BunsSearchApi.Web.Contracts;

public class SearchBunRequest
{
    [JsonPropertyName("request_id")]
    public required string RequestId { get; set; }
    [JsonPropertyName("bun_name")]
    public required string BunName { get; set; }
    [JsonPropertyName("search_type")]
    public required string SearchType { get; set; }
}