using System.ComponentModel.DataAnnotations;
using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BunsSearchApi.Web.Controllers;

[Route("api/v1/bun")]
[ApiController]
public class BunController(
    IBunSearchService bunSearchService) : ControllerBase
{
    [HttpGet("{bunName}/history")]
    public async Task<IActionResult> GetBunHistory(
        [FromRoute(Name = "bunName"), Required] string bunName,
        CancellationToken cancellationToken)
    {
        var bun = await bunSearchService.SearchBunHistory(bunName, cancellationToken);
        return Ok(bun.ToResponse());
    }
    
    [HttpGet("{bunName}/story")]
    public async Task<IActionResult> GetBunStory(
        [FromRoute(Name = "bunName"), Required] string bunName,
        CancellationToken cancellationToken)
    {
        var bun = await bunSearchService.SearchBunStory(bunName, cancellationToken);
        return Ok(bun.ToResponse());
    }
    
    [HttpGet("{bunName}/recipe")]
    public async Task<IActionResult> GetBunRecipe(
        [FromRoute(Name = "bunName"), Required] string bunName,
        CancellationToken cancellationToken)
    {
        var bun = await bunSearchService.SearchBunRecipe(bunName, cancellationToken);
        return Ok(bun.ToResponse());
    }
}