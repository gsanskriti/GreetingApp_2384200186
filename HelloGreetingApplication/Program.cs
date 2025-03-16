using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using businessLayer.@interface;
using businessLayer.services;
using repositoryLayer.@interface;
using repositoryLayer.services;
using Microsoft.EntityFrameworkCore;
using repositoryLayer.Context;
using HelloGreetingApplication.Middleware;

// Configure logger
var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();

logger.Info("Started app...");

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Register DbContext 

builder.Services.AddDbContext<HelloGreetingContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HelloGreetingContext")));

// Register Layer
builder.Services.AddScoped<IGreetingAppBL, GreetingAppBL>();
builder.Services.AddScoped<IGreetingAppRL, GreetingAppRL>();

// Add services to the container.
builder.Services.AddControllers();

// Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GreetingApp API",
        Version = "v1",
        Description = "API for managing greetings",
        Contact = new OpenApiContact
        {
            Name = "Sanskriti Gupta",
            Email = "gsanskriti023@gmail.com"
        }
    });
});



var app = builder.Build();

// Enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GreetingApp API v1");
    });
}

// Use Global Exception Handling Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
