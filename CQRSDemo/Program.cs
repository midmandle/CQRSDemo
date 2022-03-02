using CQRSDemo.Data;
using CQRSDemo.Handlers;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var handlersAssembly = typeof(GetWeatherForecastHandler).Assembly;
builder.Services.AddMediatR(handlersAssembly);
builder.Services.AddFluentValidation(new[] {handlersAssembly});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();