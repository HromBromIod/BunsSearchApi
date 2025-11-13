using System.Runtime.CompilerServices;
using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.BusinessLogic.Models;
using BunsSearchApi.Integration.OllamaAi.Contracts;
using BunsSearchApi.Integration.OllamaAi.Services;
using Microsoft.Extensions.Logging;

namespace BunsSearchApi.BusinessLogic.Services.Implementation;

public class BunStreamSearchService(
    IOllamaService ollamaService,
    ILogger<BunStreamSearchService> logger) : IBunStreamSearchService
{
    public async IAsyncEnumerable<BunChunk> SearchAsStream(string bunName, string searchType, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string prompt;
        switch (searchType)
        {
            case SearchParameters.History:
                prompt = string.Format(PromptPatterns.SearchBunHistoryPromptPattern, bunName);
                break;
            case SearchParameters.Story:
                prompt = string.Format(PromptPatterns.SearchBunStoryPromptPattern, bunName);
                break;
            case SearchParameters.Recipe:
                prompt = string.Format(PromptPatterns.SearchBunRecipePromptPattern, bunName);
                break;
            default:
                yield break;
        }
        
        logger.LogInformation("BunStreamSearchService has started receiving");
        
        var request = new OllamaRequest(Guid.NewGuid().ToString(), prompt);
        await foreach (var ollamaChunk in ollamaService.GetResponseAsStream(request, cancellationToken))
        {
            yield return new BunChunk
            {
                Name = bunName,
                MessageTextChunk = ollamaChunk.Content,
                IsComplete = ollamaChunk.IsComplete
            };
        }
        
        logger.LogInformation("BunStreamSearchService has completed receiving");
    }
}