using System.Threading.Channels;
using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.Web.Contracts;
using BunsSearchApi.Web.Models;
using Microsoft.AspNetCore.SignalR;

namespace BunsSearchApi.Web.SignalR;

public class BunSearchChannelHub(
    IBunStreamSearchService streamSearchService,
    ILogger<BunSearchHub> logger) : Hub
{
    public ChannelReader<SearchBunChunkResponse> SearchHistoryChannel(SearchBunRequest request, CancellationToken cancellationToken)
    {
        var channel = Channel.CreateUnbounded<SearchBunChunkResponse>();
        _ = WriteHistoryToChannel(channel.Writer, request, cancellationToken);
        return channel.Reader;
    }
    
    public ChannelReader<SearchBunChunkResponse> SearchStoryChannel(SearchBunRequest request, CancellationToken cancellationToken)
    {
        var channel = Channel.CreateUnbounded<SearchBunChunkResponse>();
        _ = WriteStoryToChannel(channel.Writer, request, cancellationToken);
        return channel.Reader;
    }
    
    public ChannelReader<SearchBunChunkResponse> SearchRecipeChannel(SearchBunRequest request, CancellationToken cancellationToken)
    {
        var channel = Channel.CreateUnbounded<SearchBunChunkResponse>();
        _ = WriteRecipeToChannel(channel.Writer, request, cancellationToken);
        return channel.Reader;
    }

    private async Task WriteHistoryToChannel(ChannelWriter<SearchBunChunkResponse> writer, SearchBunRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var stream = streamSearchService.SearchHistoryAsStream(request.BunName, cancellationToken);
            await foreach (var chunk in stream)
            {
                await writer.WriteAsync(chunk.ToResponse(), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error writing to channel for request {BunName}", request.BunName);
        }
        finally
        {
            writer.Complete();
        }
    }
    
    private async Task WriteStoryToChannel(ChannelWriter<SearchBunChunkResponse> writer, SearchBunRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var stream = streamSearchService.SearchStoryAsStream(request.BunName, cancellationToken);
            await foreach (var chunk in stream)
            {
                await writer.WriteAsync(chunk.ToResponse(), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error writing to channel for request {BunName}", request.BunName);
        }
        finally
        {
            writer.Complete();
        }
    }
    
    private async Task WriteRecipeToChannel(ChannelWriter<SearchBunChunkResponse> writer, SearchBunRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var stream = streamSearchService.SearchRecipeAsStream(request.BunName, cancellationToken);
            await foreach (var chunk in stream)
            {
                await writer.WriteAsync(chunk.ToResponse(), cancellationToken);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error writing to channel for request {BunName}", request.BunName);
        }
        finally
        {
            writer.Complete();
        }
    }
}