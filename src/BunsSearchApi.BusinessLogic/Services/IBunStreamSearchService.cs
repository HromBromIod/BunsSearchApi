using BunsSearchApi.BusinessLogic.Contracts;

namespace BunsSearchApi.BusinessLogic.Services;

public interface IBunStreamSearchService
{
    IAsyncEnumerable<BunChunk> SearchAsStream(string bunName, string searchType, CancellationToken cancellationToken = default);
}