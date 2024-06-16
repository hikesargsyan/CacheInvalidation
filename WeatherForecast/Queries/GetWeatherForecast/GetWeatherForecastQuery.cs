using CacheInvalidation.Interfaces;

namespace CacheInvalidation;

public class GetWeatherForecastQuery : ICacheableRequest<WeatherForecast>
{
    public Guid Id { get; set; }
}
