using FluentValidation;

namespace CQRSDemo.Commands;

public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
{
    public CreateWeatherForecastCommandValidator()
    {
        RuleFor(x => x.WeatherForecast.Summary)
            .NotEmpty()
            .WithMessage("Summary must not be empty");

        RuleFor(x => x.WeatherForecast.Location)
            .NotEmpty()
            .WithMessage("Location cannot be empty");
    }
}   