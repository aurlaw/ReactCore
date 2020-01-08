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

        [Fact]
        public async Task TestService() 
        {
            var mockClient = new Mock<ICaptureClient>();
            var service = new CaptureService(mockClient.Object);
            var result = await service.TestAsync("1");
            Assert.NotNull(result);
        } 
        [Fact]
        public async Task TestExecuteAsync() 
        {
            var url = "http://localhost:8020/demo";
            var model = new CaptureModel{Message="Test"};
            var capRequest = new CaptureRequest
            {
                Url = url,
                Message = model.Message
            };
            var mockClient = new Mock<ICaptureClient>();
            var reply = new CaptureReply{Message = "Test", Html = "Test"};
            mockClient.Setup(r => r.PerformAsync(capRequest)).Returns(new Grpc.Core.AsyncUnaryCall<CaptureReply>(Task.FromResult(reply), null, null, null,null));

            var service = new CaptureService(mockClient.Object);
            var result = await service.ExecuteAsync(url, model);
            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);

        } 
    }
}