using System.ComponentModel.DataAnnotations;
using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BunsSearchApi.Web.Controllers;

[Route("api/v1/buns")]
[ApiController]
public class BunsController(
    IBunsSearchService bunsSearchService) : ControllerBase
{
    [HttpGet("{bunName}")]
    public async Task<IActionResult> GetBun(
        [FromRoute(Name = "bunName"), Required] string bunName,
        [FromQuery, Required] string searchParameter,
        CancellationToken cancellationToken)
    {
        var bun = await bunsSearchService.SearchBun(bunName, searchParameter, cancellationToken);
        return Ok(bun.ToResponse());
    }
}