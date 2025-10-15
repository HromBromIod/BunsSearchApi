namespace BunsSearchApi.BusinessLogic.Contracts;

public class Bun
{
    public required string Name { get; set; }
    public required string SearchParameter { get; set; }
    public string? Message { get; set; }
}