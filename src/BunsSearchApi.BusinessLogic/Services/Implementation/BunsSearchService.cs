using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Integration.OllamaAi.Services;
using Microsoft.Extensions.Logging;

namespace BunsSearchApi.BusinessLogic.Services.Implementation;

internal class BunsSearchService(
    IOllamaService ollamaService,
    ILogger<BunsSearchService> logger): IBunsSearchService
{
    public async Task<Bun> SearchBun(string bunName, string parameter, CancellationToken cancellationToken)
    {
        
        
        return new Bun
        {
            Name = bunName,
            SearchParameter = parameter,
            Description = "some bun description",
            Type = "bun type"
        };
    }
}