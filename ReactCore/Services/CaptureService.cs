using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcService.Protos;
// using Grpc.Net.Client;
using ReactCore.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Google.Protobuf;

namespace ReactCore.Services
{
    public class CaptureService : ICaptureService
    {
        private readonly ICaptureClient _client;
        public CaptureService(ICaptureClient client)
        {
            _client = client;
        }

        public Task<string> TestAsync(string id) 
        {
            return Task.FromResult($"Test: {id}");
        }

        public async Task<Tuple<string, string>> ExecuteAsync(string url, CaptureModel model) 
        {

            var imgTuple = await GetUploadedImage(model.FormFile);

            var request = new CaptureRequest
            {
                Url = url, 
                Message = model.Message,
            };
            if(imgTuple.Item1 != null) 
            {
                request.ImageName = imgTuple.Item1;
                request.ImageType = imgTuple.Item2;
                request.ImageBytes = ByteString.CopyFrom(imgTuple.Item3);
            }
            var result = await _client.PerformAsync(request);
            return new Tuple<string, string>(result.Message, result.Html);
        }

        private async Task<Tuple< string, string, byte[]>> GetUploadedImage(IFormFile file)
        {
            if(file == null)
                return new Tuple<string, string, byte[]>(null, null, null);
             using(var stream = new MemoryStream()) 
             {
                 await file.CopyToAsync(stream);
                 return new Tuple<string, string, byte[]>(file.FileName, file.ContentType, stream.ToArray());
             }   
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
