using System.Text.Json.Serialization;

namespace BunsSearchApi.Web.Contracts;

public class SearchBunRequest
{
    [JsonPropertyName("bun_name")]
    public required string BunName { get; set; }
}