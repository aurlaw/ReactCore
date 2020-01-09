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

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }
        
        public override async Task GetWeatherStream(Empty _, IServerStreamWriter<WeatherData> responseStream, ServerCallContext context)
        {
            throw new RpcException(new Status(StatusCode.Unimplemented, ""));            
        }
        
    }
}

//https://www.stevejgordon.co.uk/server-streaming-with-grpc-in-asp-dotnet-core