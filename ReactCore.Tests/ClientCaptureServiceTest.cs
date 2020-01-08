using System;
using Xunit;
using ReactCore.Controllers;
using Moq;
using ReactCore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using ReactCore.Models;
using Grpc.Net.Client;
using GrpcService.Protos;

namespace ReactCore.Tests
{
    
    public class ClientCaptureServiceTest
    {
        const string host = "http://localhost:5000";// "https://localhost:5001";

        [Fact]
        public async Task TestService() 
        {
            var mockGrpcChannel = new Mock<GrpcChannel>();
            var service = new CaptureService();
            var result = await service.TestAsync("1");
            Assert.NotNull(result);
        } 
        [Fact]
        public async Task TestExecuteAsync() 
        {
            var url = "http://localhost:8020/demo";
            var model = new CaptureModel{Message="Test"};

/*
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
            var captureClient = new Capture.CaptureClient(_channel);
            var result = await captureClient.PerformAsync(request);

*/

            var capRequest = new CaptureRequest
            {
                Url = url,
                Message = model.Message
            };
            var mockGrpcChannel = new Mock<GrpcChannel>();
            var service = new CaptureService();
            var result = await service.ExecuteAsync(url, model);
            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);

        } 
    }
}