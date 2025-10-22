namespace BunsSearchApi.BusinessLogic.Contracts;

public class BunChunk
{
    public required string Name { get; set; }
    public required string SearchParameter { get; set; }
    public string? MessageTextPart { get; set; }
    public required bool IsComplete { get; set; }
}