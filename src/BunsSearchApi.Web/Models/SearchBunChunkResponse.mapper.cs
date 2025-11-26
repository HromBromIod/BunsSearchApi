using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Web.Contracts;

namespace BunsSearchApi.Web.Models;

public static class SearchBunChunkResponseMapper
{
    public static SearchBunChunkResponse ToResponse(this BunChunk chunk, (string MachineName, int ProcessId, DateTime Timestamp) metadata)
    {
        return new SearchBunChunkResponse
        {
            BunName = chunk.Name,
            MessageTextChunk = chunk.MessageTextChunk,
            IsCompleted = chunk.IsComplete,
            Metadata = new
            {
                machine_name = metadata.MachineName,
                process_id = metadata.ProcessId,
                timestamp = metadata.Timestamp
            }
        };
    }
}