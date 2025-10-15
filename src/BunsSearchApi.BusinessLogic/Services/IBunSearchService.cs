using BunsSearchApi.BusinessLogic.Contracts;

namespace BunsSearchApi.BusinessLogic.Services;

public interface IBunSearchService
{
    Task<Bun> SearchBunHistory(string bunName, CancellationToken cancellationToken);
    Task<Bun> SearchBunStory(string bunName, CancellationToken cancellationToken);
    Task<Bun> SearchBunRecipe(string bunName, CancellationToken cancellationToken);
}