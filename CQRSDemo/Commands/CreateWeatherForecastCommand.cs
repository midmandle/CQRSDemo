using FluentValidation;
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

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(x => x.WeatherForecast.Summary)
            .NotEmpty()
            .WithMessage("Summary must not be empty");
    }
}