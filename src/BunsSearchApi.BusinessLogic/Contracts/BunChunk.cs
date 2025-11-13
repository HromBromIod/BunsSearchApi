namespace BunsSearchApi.BusinessLogic.Contracts;

public class BunChunk
{
    public required string Name { get; set; }
    public string? MessageTextChunk { get; set; }
    public required bool IsComplete { get; set; }
}