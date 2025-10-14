namespace BunsSearchApi.BusinessLogic.Contracts;

public class Bun
{
    public required string Name { get; set; }
    public required string SearchParameter { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
}