using MediatR;

namespace CQRSDemo.Queries;

public class GetWeatherForecastQuery : IRequest<WeatherForecast[]>, IRequest<WeatherForecast>
{
    
}