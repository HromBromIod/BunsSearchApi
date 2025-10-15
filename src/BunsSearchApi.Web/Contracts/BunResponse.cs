using System.Text.Json.Serialization;

namespace BunsSearchApi.Web.Contracts;

public class BunResponse
{
    [JsonPropertyName("bun_name")]
    public required string Name { get; set; }
    [JsonPropertyName("search_parameter")]
    public required string SearchParameter { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}