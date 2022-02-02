using CQRSDemo.Handlers;
using CQRSDemo.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        GetWeatherForecastQuery query = new GetWeatherForecastQuery();
        return await new GetWeatherForecastHandler().Handle(query, CancellationToken.None);
    }
}