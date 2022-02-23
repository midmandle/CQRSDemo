using CQRSDemo.Data;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, WeatherForecast[]>
{
    private readonly IWeatherRepository _weatherRepository;

    public GetWeatherForecastHandler(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }


    public async Task<WeatherForecast[]> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        return await _weatherRepository.GetAll();
    }
}