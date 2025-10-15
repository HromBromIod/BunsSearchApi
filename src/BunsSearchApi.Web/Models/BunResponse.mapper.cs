using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Web.Contracts;

namespace BunsSearchApi.Web.Models;

public static class BunResponseMapper
{
    public static BunResponse ToResponse(this Bun bun)
    {
        return new BunResponse
        {
            Name = bun.Name,
            SearchParameter = bun.SearchParameter,
            Message = bun.Message
        };
    }
}