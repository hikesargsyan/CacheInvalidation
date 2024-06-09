using System.Reflection;
using CacheInvalidation;
using CacheInvalidation.Behaviors;
using CacheInvalidation.Interfaces;
using CacheInvalidation.Services;
using MediatR;

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
        async (IMediator mediator) => await mediator.Send(new GetWeatherForecastQuery())
    )
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapPost(
        "/weatherforecast",
        async (AddCityToWeatherForecastCommand request, IMediator mediator) => await mediator.Send(request)
    )
    .WithName("AddCity")
    .WithOpenApi();

app.Run();
