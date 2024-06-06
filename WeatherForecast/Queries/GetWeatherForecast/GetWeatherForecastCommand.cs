using MediatR;

namespace CacheInvalidation;

public class GetWeatherForecastCommand : IRequest<List<WeatherForecast>>;
