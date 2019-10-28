using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Protos;
using Grpc.Net.Client;


namespace ReactCore.Services
{
    public class CaptureService : ICaptureService
    {
        private readonly GrpcChannel _channel;

        public CaptureService()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
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
