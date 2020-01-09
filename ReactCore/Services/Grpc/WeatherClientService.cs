using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Protos;
using Microsoft.Extensions.Options;
using ReactCore.Config;
using static GrpcService.Protos.WeatherForecasts;

namespace ReactCore.Services.Grpc
{
    public class WeatherClientService : ClientBase, IWeatherClient
    {
        public WeatherClientService(IOptions<GrpcOptions> options) : base(options)
        {
        }

        public AsyncServerStreamingCall<WeatherData> GetWeatherStream(Empty request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
        {
            var client  = new WeatherForecastsClient(_channel);
            return client.GetWeatherStream(request, headers, deadline, cancellationToken);
        }

        public AsyncServerStreamingCall<WeatherData> GetWeatherStream(Empty request, CallOptions options)
        {
            var client  = new WeatherForecastsClient(_channel);
            return client.GetWeatherStream(request, options);
        }
    }
}