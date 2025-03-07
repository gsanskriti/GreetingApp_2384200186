using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;

// Configure logger
var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();

logger.Info("Started app...");

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Logging.AddConsole();   
builder.Logging.AddDebug();

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

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
