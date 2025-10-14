using BunsSearchApi.Web.Application;

var builder = WebApplication.CreateBuilder(args);

builder.BuildApplication();

var app = builder.Build();
app.CreateApplication();

app.Run();