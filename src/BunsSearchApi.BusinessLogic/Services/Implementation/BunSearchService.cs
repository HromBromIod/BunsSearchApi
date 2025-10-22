using System.Text.RegularExpressions;
using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.BusinessLogic.Models;
using BunsSearchApi.Integration.OllamaAi.Services;

namespace BunsSearchApi.BusinessLogic.Services.Implementation;

internal class BunSearchService(IOllamaService ollamaService): IBunSearchService
{
    private const string ErrorBunMessageText = "Bun not found";

    public async Task<Bun> SearchBunHistory(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunHistoryPromptPattern, bunName);
        return await InternalSendPrompt(bunName, SearchParameters.History, prompt, cancellationToken);
    }

    public async Task<Bun> SearchBunStory(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunHistoryPromptPattern, bunName);
        return await InternalSendPrompt(bunName, SearchParameters.Story, prompt, cancellationToken);
    }

    public async Task<Bun> SearchBunRecipe(string bunName, CancellationToken cancellationToken)
    {
        var prompt = string.Format(PromptPatterns.SearchBunHistoryPromptPattern, bunName);
        return await InternalSendPrompt(bunName, SearchParameters.Recipe, prompt, cancellationToken);
    }

    private async Task<Bun> InternalSendPrompt(string bunName, string searchParameter, string prompt, CancellationToken cancellationToken)
    {
        var resultBun = new Bun
        {
            Name = bunName,
            SearchParameter = searchParameter,
        };
        
        var result = await ollamaService.GetResponse(prompt, cancellationToken);
        if (result == null)
        {
            resultBun.MessageText = ErrorBunMessageText;
            return resultBun;
        }
        
        resultBun.MessageText = Regex.Unescape(result.Response);
        return resultBun;
    }
}