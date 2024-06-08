using MediatR;

namespace CacheInvalidation;

public class GetWeatherForecastQueryHandler
    : IRequestHandler<GetWeatherForecastQuery, List<WeatherForecast>>
{
    public GetWeatherForecastQueryHandler() { }

    public async Task<List<WeatherForecast>> Handle(
        GetWeatherForecastQuery request,
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

        // Imitating long running request
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        return
            Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToList();

    }
}
