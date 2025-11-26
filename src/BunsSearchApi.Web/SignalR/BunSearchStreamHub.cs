using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Contracts;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace BunsSearchApi.Web.SignalR;

public class BunSearchStreamHub(
    IBunStreamSearchService streamSearchService,
    ILogger<BunSearchStreamHub> logger) : Hub
{
    public async Task Search(SearchBunRequest request)
    {
        logger.LogInformation("StartStreaming called for request: {RequestId}", request.RequestId);
        
        try
        {
            var chunkCounter = 0;
            await foreach (var chunk in streamSearchService.SearchAsStream(request.BunName, request.SearchType).WithCancellation(Context.ConnectionAborted))
            {
                chunkCounter += 1;
                logger.LogInformation("Current chunks count {ChunksCount} for request: {RequestId}", chunkCounter, request.RequestId);
                await Clients.Caller.SendAsync("ReceiveChunk", chunk.ToResponse(GetMetadata()), cancellationToken: Context.ConnectionAborted);
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Streaming canceled for request: {RequestId}", request.RequestId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during streaming for request: {RequestId}", request.RequestId);
            await Clients.Caller.SendAsync("StreamError", request.RequestId, ex.Message);
        }
    }
    
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    private static (string MachineName, int ProcessId, DateTime Timestamp) GetMetadata()
    {
        return (Environment.MachineName, Environment.ProcessId, DateTime.UtcNow);
    }
}