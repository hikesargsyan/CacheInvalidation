namespace CacheInvalidation;

public record WeatherForecast(DateOnly Date, int TemperatureC, string City)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public static readonly IList<string> Cities =
    [
        "London",
        "Paris",
        "Berlin",
        "Moscow",
        "Tokyo"
    ];
}
