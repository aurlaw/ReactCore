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

namespace ReactCore.Tests
{
    public class PuppeteerTest
    {
        private readonly Mock<IWebHostEnvironment> mockEnvironment;
        public PuppeteerTest() 
        {
            mockEnvironment = new Mock<IWebHostEnvironment>();
            mockEnvironment.Setup(x => x.EnvironmentName).Returns("Development");
        }
        [Fact]
        public async Task TestIndex()
        {
            var testId = "1";
            // var request = new Mock<HttpRequest>();
            // var context = new Mock<HttpContext>();
            var mockCapture = new Mock<ICaptureService>();

            // context.SetupGet(x => x.Request).Returns(request.Object);
            mockCapture.Setup(x => x.TestAsync(testId)).ReturnsAsync(testId);    

            var controller = new PuppeteerController(mockEnvironment.Object, mockCapture.Object);
            // controller.ControllerContext = new ActionContext(context.Object, new RouteData()
            var result = await controller.Index(testId);
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public async Task TestCapture()
        {
            var url = "http://localhost:8020/demo";
            var model = new CaptureModel{Message="Test"};
            var request = new Mock<HttpRequest>();
            request.SetupGet(r => r.Scheme).Returns("http");
            request.SetupGet(r => r.Host).Returns(new HostString("localhost", 8020));
            var context = new Mock<HttpContext>();
            var mockCapture = new Mock<ICaptureService>();
            context.SetupGet(x => x.Request).Returns(request.Object);
            mockCapture.Setup(x => x.ExecuteAsync(url, model)).ReturnsAsync(new Tuple<string, string>("Data", "HTML"));   

            var controller = new PuppeteerController(mockEnvironment.Object, mockCapture.Object);
            controller.ControllerContext = new ControllerContext(){HttpContext = context.Object};
            
            var result = await controller.Capture(model);
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);

            
        }


    }
}

/*
        public async Task<IActionResult> Capture([FromForm]CaptureModel model) 
        {
            var host = Request.Host;
            var scheme  = Request.Scheme;
            var urlHost = $"{scheme}://{host.Host}:{host.Port}";
            if (env.IsDevelopment()) {
                urlHost = "http://localhost:8020";
            }
            var url = $"{urlHost}/demo";
            var demoData = await _captureService.ExecuteAsync(url, model);

            return Ok(new {
                message = demoData.Item1,
                html = demoData.Item2,
                scheme = scheme,
                host = host.Host,
                Port = host.Port,
                urlHost = url
            }); 
        }        
https://github.com/moq/moq4
https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
https://stackoverflow.com/questions/970198/how-to-mock-the-request-on-controller-in-asp-net-mvc
*/