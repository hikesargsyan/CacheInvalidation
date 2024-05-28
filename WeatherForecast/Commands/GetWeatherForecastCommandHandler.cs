using MediatR;

namespace CacheInvalidation;

public class GetWeatherForecastCommandHandler
    : IRequestHandler<GetWeatherForecastCommand, List<WeatherForecast>>
{
    public GetWeatherForecastCommandHandler() { }

    public Task<List<WeatherForecast>> Handle(
        GetWeatherForecastCommand request,
        CancellationToken cancellationToken
    )
    {
        var summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        return Task.FromResult(
            Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToList()
        );
    }
}
