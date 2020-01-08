using Grpc.Core;
using GrpcService.Protos;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;
using System.Web;

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
            var url  = request.Url;
            var imageUrl = "/images/background.jpg";
            if(request.ImageBytes != null && !string.IsNullOrEmpty(request.ImageName )) 
            {
                imageUrl =  await _storageService.SaveDocument(request.ImageName, request.ImageBytes.ToByteArray());
            }
            var keyValuePairs = new NameValueCollection();
            keyValuePairs.Add("imageUrl", imageUrl);
            keyValuePairs.Add("message", request.Message);                
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var options = new LaunchOptions
            {
                Headless = true
            };
            using (var browser = await Puppeteer.LaunchAsync(options))
            using(var page = await browser.NewPageAsync()) 
            {
                await page.SetRequestInterceptionAsync(true);
                page.Request += async (sender, e) =>
                {
                    if(e.Request.Url != url) 
                    {
                        await e.Request.ContinueAsync();
                        return;
                    }
                    //
                    var payload = new Payload()
                    {
                        Headers = new Dictionary<string, string>{{"Content-Type", "application/x-www-form-urlencoded"}},
                        Url = url,
                        Method = HttpMethod.Post,
                        PostData = String.Join("&",
                             keyValuePairs.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(keyValuePairs[a])))
                    };
                    await e.Request.ContinueAsync(payload);
                    await Console.Out.WriteLineAsync($"REQUEST: {e.Request.Method} {e.Request.Url} {payload.PostData}");
                };
                page.Response += async (sender, e) =>
                {
                    await Console.Out.WriteLineAsync($"RESPONSE: {e.Response.Url} -({e.Response.Request.Method}) {e.Response.Status:d} {e.Response.StatusText}");
                };
                await page.GoToAsync(url);
                var pageData = await page.ScreenshotBase64Async(new ScreenshotOptions{Type= ScreenshotType.Jpeg, Quality= 100});
                return new CaptureReply
                {
                    Message = pageData
                };
            }
        }

    }
}