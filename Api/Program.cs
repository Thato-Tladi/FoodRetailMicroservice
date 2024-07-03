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

string? allAllowedOrigins = builder.Configuration["AppSettings:AllowedOrigins"];

string[] allowedOrigins = [];

if (allAllowedOrigins != null)
{
    allowedOrigins = allAllowedOrigins.Split(",");
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FoodRetailContext>();

builder.Services.AddScoped<IConsumerHistoryRepository, ConsumerHistoryRepository>();

builder.Services.AddScoped<IFinancialInfoRepository, FinancialInfoRepository>();

builder.Services.AddScoped<IConsumerHistoryService, ConsumerHistoryService>();

builder.Services.AddScoped<IFinancialInfoService, FinancialInfoService>();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodRetailer API", Version = "v1" });

    config.EnableAnnotations();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

string originsKey = "origins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: originsKey,
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                .WithMethods("GET")
                .AllowAnyHeader();
        });
});

builder.Services.AddHttpClient<StockExchangeService>((serviceProvider, client) =>
{
    client.DefaultRequestHeaders.Add("X-Origin", BusinessConstants.BUSINESS_NAME);
    client.BaseAddress = new Uri("https://api.mese.projects.bbdgrad.com");
});

var app = builder.Build();

app.UseCors(originsKey);

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
