using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Protos;

namespace ReactCore.Services.Grpc
{
    public interface IWeatherClient
    {
      AsyncServerStreamingCall<global::GrpcService.Protos.WeatherData> GetWeatherStream(global::Google.Protobuf.WellKnownTypes.Empty request, Metadata headers = null, System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
      AsyncServerStreamingCall<global::GrpcService.Protos.WeatherData> GetWeatherStream(global::Google.Protobuf.WellKnownTypes.Empty request, CallOptions options);

    }
}