using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Contracts;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace BunsSearchApi.Web.SignalR;

public class BunHub(IBunSearchService searchService) : Hub
{
    public async Task<BunResponse> SearchHistory(BunRequest request)
    {
        var result = await searchService.SearchBunHistory(request.BunName, CancellationToken.None);
        return result.ToResponse();
    }
    
    public async Task<BunResponse> SearchStory(BunRequest request)
    {
        var result = await searchService.SearchBunStory(request.BunName, CancellationToken.None);
        return result.ToResponse();
    }
    
    public async Task<BunResponse> SearchRecipe(BunRequest request)
    {
        var result = await searchService.SearchBunRecipe(request.BunName, CancellationToken.None);
        return result.ToResponse();
    }
}