using MediatR;
using System;

namespace CacheInvalidation;

public class RefreshWeatherForecastCommandHandler
    : IRequestHandler<RefreshWeatherForecastCommand, WeatherForecast>
{
    public RefreshWeatherForecastCommandHandler() { }

    public async Task<WeatherForecast> Handle(
       RefreshWeatherForecastCommand request,
        CancellationToken cancellationToken
    )
    {
        var city = WeatherForecast.Cities.FirstOrDefault(c => c.Id == request.Id);

        if (city == null)
        {
            throw new Exception("not found");
        }

        return await Task.FromResult(new WeatherForecast(
                DateOnly.FromDateTime(DateTime.UtcNow),
                Random.Shared.Next(-20, 55),
                city.Name
        ));
    }
}
