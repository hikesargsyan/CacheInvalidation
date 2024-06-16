namespace CacheInvalidation;


public class WeatherCity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string City)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public static readonly IList<WeatherCity> Cities =
    [

        new WeatherCity()
        {
            Id = Guid.Parse("19bd982b-adf0-405c-85a8-719e6a0f5cb0"),
            Name = "London"
        },
        new WeatherCity()
        {
            Id = Guid.Parse("29bd982b-adf0-405c-85a8-719e6a0f5cb0"),
            Name = "Paris"
        },
        new WeatherCity()
        {
            Id = Guid.Parse("39bd982b-adf0-405c-85a8-719e6a0f5cb0"),
            Name = "Berlin"
        }
    ];
}
