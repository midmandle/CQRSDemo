using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecast[]>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public async Task<WeatherForecast[]> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}