using MediatR;

namespace CQRSDemo.Queries;

public class GetWeatherForecastQuery : IRequest<WeatherForecast[]>
{
    public string Location { get; }

    public GetWeatherForecastQuery(string location)
    {
        Location = location ?? throw new ArgumentNullException();
    }
}