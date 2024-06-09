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
        // Imitating long running request
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        return Enumerable
            .Range(1, WeatherForecast.Cities.Count - 1)
            .Select(index => new WeatherForecast(
                DateOnly.FromDateTime(DateTime.UtcNow),
                Random.Shared.Next(-20, 55),
                WeatherForecast.Cities[index]
            ))
            .ToList();

    }
}
