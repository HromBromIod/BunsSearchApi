using BunsSearchApi.BusinessLogic;
using BunsSearchApi.Integration;
using BunsSearchApi.Web.Application.Middlewares;
using BunsSearchApi.Web.SignalR;

namespace BunsSearchApi.Web.Application;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder BuildApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient();
        builder.Services.AddIntegrations(builder.Configuration);
        
        builder.Services.AddBusinessLogic();

        builder.Services.AddSignalR();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplication CreateApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        
        app.UseExceptionHandling(app.Services.GetRequiredService<ILoggerFactory>());
        app.MapControllers();
        app.MapHub<BunSearchHub>("/hub/bun/search");
        app.MapHub<BunSearchChannelHub>("/hub/bun/search/channel");

        return app;
    }
}