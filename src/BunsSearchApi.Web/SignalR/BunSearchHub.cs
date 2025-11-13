using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Contracts;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace BunsSearchApi.Web.SignalR;

public class BunSearchHub(
    IBunSearchService searchService,
    ILogger<BunSearchHub> logger) : Hub
{
    public async Task SearchHistory(SearchBunRequest request)
    {
        var result = await searchService.SearchBunHistory(request.BunName, CancellationToken.None);
        await Clients.Caller.SendAsync("SearchResponse", result.ToResponse());
    }
    
    public async Task SearchStory(SearchBunRequest request)
    {
        var result = await searchService.SearchBunStory(request.BunName, CancellationToken.None);
        await Clients.Caller.SendAsync("SearchResponse", result.ToResponse());
    }
    
    public async Task SearchRecipe(SearchBunRequest request)
    {
        var result = await searchService.SearchBunRecipe(request.BunName, CancellationToken.None);
        await Clients.Caller.SendAsync("SearchResponse", result.ToResponse());
    }
}