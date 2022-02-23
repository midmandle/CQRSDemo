namespace CQRSDemo.Data;

public interface IWeatherRepository
{
    Task<WeatherForecast[]> GetAll();

    Task Add(WeatherForecast weatherForecast);
}