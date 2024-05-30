using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services
    .AddApplication()
    .AddInfrastructure(configuration);

builder.Services.AddControllers();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();