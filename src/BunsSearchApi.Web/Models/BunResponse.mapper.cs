using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Web.Contracts;

namespace BunsSearchApi.Web.Models;

public static class BunResponseMapper
{
    public static SearchBunResponse ToResponse(this Bun bun)
    {
        return new SearchBunResponse
        {
            BunName = bun.Name,
            SearchParameter = bun.SearchParameter,
            MessageText = bun.MessageText
        };
    }
}