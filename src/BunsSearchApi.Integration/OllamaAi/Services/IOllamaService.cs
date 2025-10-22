using BunsSearchApi.Integration.OllamaAi.Contracts;

namespace BunsSearchApi.Integration.OllamaAi.Services;

public interface IOllamaService
{
    Task<OllamaResponse?> GetResponse(string prompt, CancellationToken cancellationToken);

    IAsyncEnumerable<OllamaChunkResponse>? GetResponseAsStream(string prompt, CancellationToken cancellationToken);
}