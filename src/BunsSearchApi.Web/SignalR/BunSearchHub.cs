using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Contracts;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace BunsSearchApi.Web.SignalR;

public class BunSearchHub(
    IBunSearchService searchService,
    ILogger<BunSearchHub> logger) : Hub
{
    public async Task<SearchBunResponse> SearchHistory(SearchBunRequest request)
    {
        var result = await searchService.SearchBunHistory(request.BunName, CancellationToken.None);
        return result.ToResponse(GetMetadata());
    }
    
    public async Task<SearchBunResponse> SearchStory(SearchBunRequest request)
    {
        var result = await searchService.SearchBunStory(request.BunName, CancellationToken.None);
        return result.ToResponse(GetMetadata());
    }
    
    public async Task<SearchBunResponse> SearchRecipe(SearchBunRequest request)
    {
        var result = await searchService.SearchBunRecipe(request.BunName, CancellationToken.None);
        return result.ToResponse(GetMetadata());
    }
    
    private static (string MachineName, int ProcessId, DateTime Timestamp) GetMetadata()
    {
        return (Environment.MachineName, Environment.ProcessId, DateTime.UtcNow);
    }
}