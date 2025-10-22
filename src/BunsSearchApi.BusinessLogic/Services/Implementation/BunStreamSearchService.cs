using System.Runtime.CompilerServices;
using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.BusinessLogic.Models;
using BunsSearchApi.Integration.OllamaAi.Services;
using Microsoft.Extensions.Logging;

namespace BunsSearchApi.BusinessLogic.Services.Implementation;

public class BunStreamSearchService(
    IOllamaService ollamaService,
    ILogger<BunStreamSearchService> logger) : IBunStreamSearchService
{
    public IAsyncEnumerable<BunChunk> SearchHistoryAsStream(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunHistoryPromptPattern, bunName);
        return InternalSendPrompt(bunName, SearchParameters.History, prompt, cancellationToken);
    }

    public IAsyncEnumerable<BunChunk> SearchStoryAsStream(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunStoryPromptPattern, bunName);
        return InternalSendPrompt(bunName, SearchParameters.Story, prompt, cancellationToken);
    }

    public IAsyncEnumerable<BunChunk> SearchRecipeAsStream(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunRecipePromptPattern, bunName);
        return InternalSendPrompt(bunName, SearchParameters.Recipe, prompt, cancellationToken);
    }
    
    private async IAsyncEnumerable<BunChunk> InternalSendPrompt(string bunName, string searchParameter, string prompt, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var resultChunk = new BunChunk
        {
            Name = bunName,
            SearchParameter = searchParameter,
            IsComplete = false
        };
        
        try
        {
            var searchStream = ollamaService.GetResponseAsStream(prompt, cancellationToken);
            if (searchStream == null)
                yield break;
            
            var chunkNumber = 0;
            await foreach (var ollamaChunk in searchStream.WithCancellation(cancellationToken))
            {
                if (cancellationToken.IsCancellationRequested)
                    yield break;
                
                resultChunk.IsComplete = ollamaChunk.Done;
                resultChunk.MessageTextPart = ollamaChunk.Content;
                
                logger.LogDebug("Sent {ChunkCount} chunks for request {BunName}", chunkNumber++, bunName);
            }

            logger.LogInformation("Stream completed for request {BunName}", bunName);
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Stream cancelled for request {BunName}", bunName);
            yield break;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in stream search for request {BunName}", bunName);
            yield break;
        }

        yield return resultChunk;
    }
}