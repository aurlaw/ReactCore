using GrpcService.Protos;

namespace ReactCore.Services
{
    public interface ICaptureClient
    {
        Grpc.Core.AsyncUnaryCall<CaptureReply> PerformAsync(CaptureRequest request);

    }
}