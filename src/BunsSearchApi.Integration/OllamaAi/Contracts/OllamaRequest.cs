using System.Text.Json.Serialization;

namespace BunsSearchApi.Integration.OllamaAi.Contracts;

public record OllamaRequest(string RequestId, string Promt);