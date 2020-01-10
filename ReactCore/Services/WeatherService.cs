using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ReactCore.Hubs;
using ReactCore.Models;
using ReactCore.Services.Grpc;

namespace ReactCore.Services
{
    public class WeatherService : IWeatherService
    {

        private readonly ILogger<WeatherService> _logger;
        private readonly IWeatherClient _client;

        public WeatherService(ILogger<WeatherService> logger, IWeatherClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task GetWeatherAsync(Action<WeatherModel> action)
        {
            var cancelToken = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            using var streamingCall = _client.GetWeatherStream(new Google.Protobuf.WellKnownTypes.Empty(), cancellationToken: cancelToken.Token);
            try
            {
                await foreach(var weather in streamingCall.ResponseStream.ReadAllAsync(cancellationToken: cancelToken.Token))
                {
                    _logger.LogInformation($"{weather.DateTime.ToDateTime():s} | {weather.Summary} | {weather.TemperatureC} C | {weather.TemperatureF} F");
                    action(new WeatherModel(weather));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
            {
                _logger.LogInformation("Weather Stream cancelled from client");
                action(new WeatherModel(ex));
            }
        }
    }
}