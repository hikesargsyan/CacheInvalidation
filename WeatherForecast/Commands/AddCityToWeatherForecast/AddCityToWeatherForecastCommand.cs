using CacheInvalidation.Interfaces;

namespace CacheInvalidation;

public class AddCityToWeatherForecastCommand : ICacheInvalidatorRequest<int>
{
    public string City { get; set; }
    public IList<string> CacheInvalidationKeys { get; } = [nameof(GetWeatherForecastQuery)];
};
