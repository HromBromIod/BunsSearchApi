using BunsSearchApi.BusinessLogic.Contracts;

namespace BunsSearchApi.BusinessLogic.Services;

public interface IBunsSearchService
{
    Task<Bun> SearchBun(string bunName, string parameter, CancellationToken cancellationToken);
}