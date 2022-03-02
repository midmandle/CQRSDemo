using CQRSDemo.Commands;
using CQRSDemo.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var query = new GetWeatherForecastQuery();
        return await _mediator.Send(query);
        // return await new GetWeatherForecastHandler().Handle(query, CancellationToken.None);
    }
    
    [HttpPost(Name = "AddWeatherForecast")]
    public async Task<IActionResult> Post(WeatherForecast weatherForecast)
    {
        var command = new CreateWeatherForecastCommand(weatherForecast);

        try
        {
            await _mediator.Send(command);
            return Ok();
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, @"Unexpected exception in {Controller}.{MethodName}", nameof(WeatherForecastController), nameof(Post));
            return StatusCode(500, "Unexpected exception");
        }
    }
}