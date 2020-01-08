using System;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Protos;

namespace ReactCore.Services
{
    public class CaptureClientService : ICaptureClient
    {
        const string host = "http://localhost:5000";// "https://localhost:5001";
        private readonly GrpcChannel _channel;


        public CaptureClientService( )
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            _channel = GrpcChannel.ForAddress(host);

        }
        public AsyncUnaryCall<CaptureReply> PerformAsync(CaptureRequest request)
        {
            var captureClient = new Capture.CaptureClient(_channel);
            return captureClient.PerformAsync(request);
        }
    }
}