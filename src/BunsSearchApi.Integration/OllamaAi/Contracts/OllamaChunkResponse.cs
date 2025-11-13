namespace BunsSearchApi.Integration.OllamaAi.Contracts;

public record OllamaChunkResponse(string RequestId, string Content, bool IsComplete);