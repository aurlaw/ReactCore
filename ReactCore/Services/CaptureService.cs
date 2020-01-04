using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Protos;
using Grpc.Net.Client;
using ReactCore.Models;

namespace ReactCore.Services
{
    public class CaptureService : ICaptureService
    {
        const string host = "http://localhost:5000";// "https://localhost:5001";
        private readonly GrpcChannel _channel;

        public CaptureService()
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            _channel = GrpcChannel.ForAddress(host);
        }

        public Task<string> TestAsync(string id) 
        {
            return Task.FromResult($"Test: {id}");
        }

        public async Task<string> ExecuteAsync(string url, CaptureModel model) 
        {
            var captureClient = new Capture.CaptureClient(_channel);
            var result = await captureClient.PerformAsync(new CaptureRequest
                {
                    Url = url, 
                    Message = model.Message
                });
            return result.Message;
        }
    }
}
/*
  // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var captureClient = new Capture.CaptureClient(_channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
     */
