using CacheInvalidation.Interfaces;

namespace CacheInvalidation;

public class RefreshWeatherForecastCommand : ICacheInvalidatorRequest<WeatherForecast>
{
    public IList<string> CacheInvalidationKeys { get; } = [nameof(GetWeatherForecastQuery)];

    public Guid Id { get; set; }
};
