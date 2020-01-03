using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class CaptureService : Capture.CaptureBase
    {
        private readonly ILogger<CaptureService> _logger;
        private readonly IStorage _storageService;
        private readonly IScreenService _screenService;

        public CaptureService(ILogger<CaptureService> logger, IScreenService screenService, IStorage storage)
        {
            _logger = logger;
            _screenService = screenService;
            _storageService = storage;
        }

        public async override Task<CaptureReply> Perform(CaptureRequest request, ServerCallContext context)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var url  = request.Name;
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            var pageData = await page.ScreenshotBase64Async(new ScreenshotOptions{Type= ScreenshotType.Jpeg, Quality= 100});
            return new CaptureReply
            {
                Message = pageData
            };
        }

    }
}