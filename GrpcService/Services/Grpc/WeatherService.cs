using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GrpcService.Services.Grpc
{
    public class WeatherService : WeatherForecasts.WeatherForecastsBase
    {
        private readonly ILogger<WeatherService> _logger;
        private static readonly string[] _summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }
        
        public override async Task GetWeatherStream(Empty _, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            var max = 20;
            var i = 0;
            var now = DateTime.UtcNow;
            var random = new Random();
            while(!context.CancellationToken.IsCancellationRequested && i < max)
            {
                var forecast = new WeatherData
                {
                    DateTime = Timestamp.FromDateTime(now.AddDays(i++)),
                    TemperatureC = random.Next(-20, 50),
                    Summary = _summaries[random.Next(_summaries.Length)]
                };
                forecast.TemperatureF = (forecast.TemperatureC * 9/5) + 32;

                _logger.LogInformation("Sending weather response");
                await responseStream.WriteAsync(forecast);

                await Task.Delay(500); //simulate latency
            }
            if(context.CancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("THe client cancelled request");
            }   
        }
        
    }
}
//https://www.stevejgordon.co.uk/server-streaming-with-grpc-in-asp-dotnet-core