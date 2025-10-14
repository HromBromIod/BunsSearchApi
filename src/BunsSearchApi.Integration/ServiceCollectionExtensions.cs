using BunsSearchApi.Core.Settings;
using BunsSearchApi.Integration.OllamaAi.Services;
using BunsSearchApi.Integration.OllamaAi.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BunsSearchApi.Integration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrations(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<OllamaApiSettings>(configuration.GetRequiredSection(nameof(OllamaApiSettings)));
        
        serviceCollection.AddScoped<IOllamaService, OllamaService>();
        
        return serviceCollection;
    }
}