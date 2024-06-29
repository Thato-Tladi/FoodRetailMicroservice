using System.Reflection;
using Amazon;
using Api.Models;
using Api.Repository;
using Api.Repository.Interfaces;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
var appName = builder.Environment.ApplicationName;

if (!builder.Environment.IsDevelopment())
{
    builder.Configuration.AddSecretsManager(region: RegionEndpoint.EUWest1,
        configurator: options =>
        {
            options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}.");
            options.KeyGenerator = (_, s) => s
                .Replace($"{env}_{appName}.", string.Empty)
                .Replace("__", ":");
            options.PollingInterval = TimeSpan.FromHours(1);
        }
    );
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FoodRetailContext>();

builder.Services.AddScoped<IConsumerHistoryRepository, ConsumerHistoryRepository>();

builder.Services.AddScoped<IConsumerHistoryService, ConsumerHistoryService>();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodRetailer API", Version = "v1" });

    config.EnableAnnotations();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
