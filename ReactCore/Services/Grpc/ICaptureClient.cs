using Grpc.Core;
using GrpcService.Protos;

namespace ReactCore.Services.Grpc
{
    public interface ICaptureClient
    {
        AsyncUnaryCall<CaptureReply> PerformAsync(CaptureRequest request);

    }
}