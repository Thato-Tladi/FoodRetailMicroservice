using System.Reflection;
using Api.Models;
using Api.Repository;
using Api.Repository.Interfaces;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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
