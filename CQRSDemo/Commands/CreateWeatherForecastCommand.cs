using MediatR;

namespace CQRSDemo.Commands;

public class CreateWeatherForecastCommand : IRequest
{
    public WeatherForecast WeatherForecast { get; }

    public CreateWeatherForecastCommand(WeatherForecast weatherForecast)
    {
        WeatherForecast = weatherForecast;
    }
}