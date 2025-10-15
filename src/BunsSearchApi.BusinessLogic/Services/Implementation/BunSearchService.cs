using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Integration.OllamaAi.Services;
using Microsoft.Extensions.Logging;

namespace BunsSearchApi.BusinessLogic.Services.Implementation;

internal class BunSearchService(
    IOllamaService ollamaService,
    ILogger<BunSearchService> logger): IBunSearchService
{
    public async Task<Bun> SearchBunHistory(string bunName, CancellationToken cancellationToken)
    {
        
        
        return new Bun
        {
            Name = bunName,
            SearchParameter = "history",
            Message = "some bun history"
        };
    }

    public async Task<Bun> SearchBunStory(string bunName, CancellationToken cancellationToken)
    {
        return new Bun
        {
            Name = bunName,
            SearchParameter = "story",
            Message = "some bun story"
        };
    }

    public async Task<Bun> SearchBunRecipe(string bunName, CancellationToken cancellationToken)
    {
        return new Bun
        {
            Name = bunName,
            SearchParameter = "recipe",
            Message = "some bun recipe"
        };
    }
}