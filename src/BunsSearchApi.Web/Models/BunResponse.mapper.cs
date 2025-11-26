using BunsSearchApi.BusinessLogic.Contracts;
using BunsSearchApi.Web.Contracts;

namespace BunsSearchApi.Web.Models;

public static class BunResponseMapper
{
    public static SearchBunResponse ToResponse(this Bun bun, (string MachineName, int ProcessId, DateTime Timestamp) metadata)
    {
        return new SearchBunResponse
        {
            BunName = bun.Name,
            SearchParameter = bun.SearchParameter,
            MessageText = bun.MessageText,
            Metadata = new
            {
                machine_name = metadata.MachineName,
                process_id = metadata.ProcessId,
                timestamp = metadata.Timestamp
            }
        };
    }
}