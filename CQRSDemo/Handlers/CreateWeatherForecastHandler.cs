using CQRSDemo.Commands;
using CQRSDemo.Data;
using MediatR;

namespace CQRSDemo.Handlers;
    
public class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForecastCommand>
{
    private readonly IWeatherRepository _weatherRepository;

    public CreateWeatherForecastHandler(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<Unit> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
    {
        await _weatherRepository.Add(request.WeatherForecast);
        
        return Unit.Value;
    }
}