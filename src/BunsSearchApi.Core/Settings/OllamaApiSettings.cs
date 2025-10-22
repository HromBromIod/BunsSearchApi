namespace BunsSearchApi.Core.Settings;

public class OllamaApiSettings
{
    public required string Url { get; init; }
    public required string ApiKey { get; init; }
    public required string Model { get; init; }
}