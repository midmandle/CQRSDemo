namespace CQRSDemo.Data;

public class WeatherRepository : IWeatherRepository
{
    private readonly List<WeatherForecast> _weatherForecasts = new();

    public Task<WeatherForecast[]> GetAll()
    {
        return Task.FromResult(_weatherForecasts.ToArray()); 
    }

    public Task Add(WeatherForecast weatherForecast)
    {
        _weatherForecasts.Add(weatherForecast);
        return Task.CompletedTask;
    }
}