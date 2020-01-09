using System;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService.Protos;
using Microsoft.Extensions.Options;
using ReactCore.Config;

namespace ReactCore.Services.Grpc
{
    public class CaptureClientService : ClientBase, ICaptureClient
    {
        public CaptureClientService( IOptions<GrpcOptions> options) : base(options)
        {

        }
        public AsyncUnaryCall<CaptureReply> PerformAsync(CaptureRequest request)
        {
            var captureClient = new Capture.CaptureClient(_channel);
            return captureClient.PerformAsync(request);
        }
    }
}