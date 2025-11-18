using System.Net.Http.Json;

namespace KlasseAuto.Blazor.Data;

public class WeatherApiService
{
    private readonly HttpClient _http;

    private const string ApiKey = "cb4fdf451cb5a71b64eb21ae7cdece03"; // <--- HIER deinen echten Key eintragen
    private const string Units = "metric"; // Celsius
    private const string Lang = "de";      // deutsche Beschreibung

    public WeatherApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<CityWeatherResult?> GetWeatherForCityAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return null;

        var cityEncoded = Uri.EscapeDataString(city.Trim());

        var currentUrl =
            $"https://api.openweathermap.org/data/2.5/weather?q={cityEncoded}&appid={ApiKey}&units={Units}&lang={Lang}";

        var forecastUrl =
            $"https://api.openweathermap.org/data/2.5/forecast?q={cityEncoded}&appid={ApiKey}&units={Units}&lang={Lang}";

        var current = await _http.GetFromJsonAsync<OpenWeatherCurrentResponse>(currentUrl);
        var forecast = await _http.GetFromJsonAsync<OpenWeatherForecastResponse>(forecastUrl);

        if (current == null || forecast == null)
            return null;

        // Aktuelles Wetter
        var currentWeatherInfo = current.Weather.FirstOrDefault();

        var currentWeather = new CurrentWeather
        {
            City = current.Name,
            TemperatureC = current.Main.Temp,
            Description = current.Weather.FirstOrDefault()?.Description ?? "Keine Beschreibung",
            Time = DateTimeOffset.FromUnixTimeSeconds(current.Dt).LocalDateTime,
            Icon = currentWeatherInfo?.Icon ?? ""
        };

        // Vorhersage: pro Tag ein Wert (Mittagszeit, wenn vorhanden)
        var byDate = forecast.List
            .GroupBy(e => DateOnly.FromDateTime(
                DateTimeOffset.FromUnixTimeSeconds(e.Dt).LocalDateTime.Date))
            .OrderBy(g => g.Key)
            .Take(5);

        var items = new List<ForecastItem>();

        foreach (var group in byDate)
        {
            var atNoon = group
                .OrderBy(e => Math.Abs(
                    DateTimeOffset.FromUnixTimeSeconds(e.Dt).LocalDateTime.Hour - 12))
                .First();

            var atNoonWeather = atNoon.Weather.FirstOrDefault();

            items.Add(new ForecastItem
            {
                Date = group.Key,
                TemperatureC = atNoon.Main.Temp,
                Description = atNoon.Weather.FirstOrDefault()?.Description ?? "",
                Icon = atNoonWeather?.Icon ?? "" 
            });
        }

        return new CityWeatherResult
        {
            City = currentWeather.City,
            Current = currentWeather,
            Forecast = items
        };
    }
}

// Modelle für das, was die API zurückgibt (vereinfachte DTOs)
public class OpenWeatherCurrentResponse
{
    public string Name { get; set; } = "";
    public long Dt { get; set; }
    public MainInfo Main { get; set; } = new();
    public List<WeatherInfo> Weather { get; set; } = new();
}

public class OpenWeatherForecastResponse
{
    public List<ForecastEntry> List { get; set; } = new();
}

public class ForecastEntry
{
    public long Dt { get; set; }
    public MainInfo Main { get; set; } = new();
    public List<WeatherInfo> Weather { get; set; } = new();
}

public class MainInfo
{
    public double Temp { get; set; }
}

public class WeatherInfo
{
    public string Description { get; set; } = "";
    public string Icon { get; set; } = ""; 
}

// Modelle für deine App:
public class CityWeatherResult
{
    public string City { get; set; } = "";
    public CurrentWeather Current { get; set; } = new();
    public List<ForecastItem> Forecast { get; set; } = new();
}

public class CurrentWeather
{
    public string City { get; set; } = "";
    public double TemperatureC { get; set; }
    public string Description { get; set; } = "";
    public DateTime Time { get; set; }
    public string Icon { get; set; } = "";
}

public class ForecastItem
{
    public DateOnly Date { get; set; }
    public double TemperatureC { get; set; }
    public string Description { get; set; } = "";
    public string Icon { get; set; } = "";
}
