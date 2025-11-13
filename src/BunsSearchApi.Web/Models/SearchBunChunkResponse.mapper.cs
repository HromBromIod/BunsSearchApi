using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Web.Contracts;

namespace BunsSearchApi.Web.Models;

public static class SearchBunChunkResponseMapper
{
    public static SearchBunChunkResponse ToResponse(this BunChunk chunk)
    {
        return new SearchBunChunkResponse
        {
            BunName = chunk.Name,
            MessageTextChunk = chunk.MessageTextChunk,
            IsCompleted = chunk.IsComplete
        };
    }
}