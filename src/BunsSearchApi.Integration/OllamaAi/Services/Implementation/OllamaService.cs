using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using BunsSearchApi.Core.Settings;
using BunsSearchApi.Integration.OllamaAi.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BunsSearchApi.Integration.OllamaAi.Services.Implementation;

internal class OllamaService(
    HttpClient httpClient,
    ILogger<OllamaService> logger,
    IOptions<OllamaApiSettings> ollamaApiOptions) : IOllamaService
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };
    
    public async Task<OllamaResponse?> GetResponse(OllamaRequest request, CancellationToken cancellationToken)
    {
        var requestBody = new
        {
            model = ollamaApiOptions.Value.Model,
            prompt = request.Promt,
            stream = false
        };
        var jsonRequest = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
        var response = await httpClient.PostAsync(ollamaApiOptions.Value.Url, content, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError($"Ошибка OllamaAPI: {response.StatusCode}. ResponseContent: {responseContent}");
            return null;
        }

        var result = JsonSerializer.Deserialize<OllamaResponse>(responseContent);
        return result;
    }
    
    public async IAsyncEnumerable<OllamaChunkResponse> GetResponseAsStream(OllamaRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var requestBody = new
        {
            model = ollamaApiOptions.Value.Model,
            prompt = request.Promt,
            stream = true
        };
        var jsonRequestBody = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");
        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(ollamaApiOptions.Value.Url),
            Content = content
        };
            
        using var response = await httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();
        
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);

        string? line;
        while ((line = await reader.ReadLineAsync(cancellationToken)) != null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(line)) yield break;

            OllamaStreamResponse? result;
            try
            {
                result = JsonSerializer.Deserialize<OllamaStreamResponse>(line, _jsonSerializerOptions);
                if (result == null) yield break;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Failed to parse Ollama Stream Response: {Line}", line);
                yield break;
            }
                
            yield return new OllamaChunkResponse(request.RequestId, result.Response ?? string.Empty, result.Done);
            
            if (result.Done) yield break;
        }
    }
}