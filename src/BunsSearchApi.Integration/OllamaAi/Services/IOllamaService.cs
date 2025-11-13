using BunsSearchApi.Integration.OllamaAi.Contracts;

namespace BunsSearchApi.Integration.OllamaAi.Services;

public interface IOllamaService
{
    Task<OllamaResponse?> GetResponse(OllamaRequest request, CancellationToken cancellationToken);

    IAsyncEnumerable<OllamaChunkResponse> GetResponseAsStream(OllamaRequest request, CancellationToken cancellationToken);
}