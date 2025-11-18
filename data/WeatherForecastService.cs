namespace KlasseAuto.Blazor.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Standard-Variante (falls woanders noch benutzt)
    public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        => GetForecastAsync(startDate, "Berlin");

    // Neue Variante: Wetter für eine bestimmte Stadt
    public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate, string city)
    {
        var rng = new Random();

        var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)],
            City = city
        }).ToArray();

        return Task.FromResult<WeatherForecast[]>(data);
    }
}
