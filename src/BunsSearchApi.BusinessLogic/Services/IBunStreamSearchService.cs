using BunsSearchApi.BusinessLogic.Contracts;

namespace BunsSearchApi.BusinessLogic.Services;

public interface IBunStreamSearchService
{
    IAsyncEnumerable<BunChunk> SearchHistoryAsStream(string bunName, CancellationToken cancellationToken);
    IAsyncEnumerable<BunChunk> SearchStoryAsStream(string bunName, CancellationToken cancellationToken);
    IAsyncEnumerable<BunChunk> SearchRecipeAsStream(string bunName, CancellationToken cancellationToken);
}