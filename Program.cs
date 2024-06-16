using System.Reflection;
using CacheInvalidation;
using CacheInvalidation.Behaviors;
using CacheInvalidation.Interfaces;
using CacheInvalidation.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheInvalidatingBehavior<,>));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<ICacheService, CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/weatherforecast",
        async ([AsParameters] GetWeatherForecastQuery request, IMediator mediator) => await mediator.Send(request)
    )
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapPut(
        "/weatherforecast",
        async (RefreshWeatherForecastCommand request, IMediator mediator) => await mediator.Send(request)
    )
    .WithName("AddCity")
    .WithOpenApi();

app.Run();
