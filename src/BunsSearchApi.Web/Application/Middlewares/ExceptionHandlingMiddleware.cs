using System.Net;

namespace BunsSearchApi.Web.Application.Middlewares;

public static class ExceptionHandlingMiddleware
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        var logger = loggerFactory.CreateLogger(nameof(ExceptionHandlingMiddleware));

        return app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Internal server error");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        });
    }
}