using BunsSearchApi.BusinessLogic.Services;
using BunsSearchApi.BusinessLogic.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BunsSearchApi.BusinessLogic;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBunSearchService, BunSearchService>();

        return serviceCollection;
    }
}