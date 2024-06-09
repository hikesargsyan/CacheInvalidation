using MediatR;

namespace CacheInvalidation;

public class AddCityToWeatherForecastCommandHandler
    : IRequestHandler<AddCityToWeatherForecastCommand, int>
{
    public AddCityToWeatherForecastCommandHandler() { }

    public async Task<int> Handle(
       AddCityToWeatherForecastCommand request,
        CancellationToken cancellationToken
    )
    {

        if (WeatherForecast.Cities.Any(c => c == request.City))
        {
            throw new Exception("This city is already in the list");
        }

        WeatherForecast.Cities.Add(request.City);
        return await Task.FromResult(WeatherForecast.Cities.IndexOf(request.City));
    }
}
