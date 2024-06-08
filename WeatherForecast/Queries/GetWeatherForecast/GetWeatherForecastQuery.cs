using CacheInvalidation.Interfaces;

namespace CacheInvalidation;

public class GetWeatherForecastQuery : ICacheableRequest<List<WeatherForecast>>;
