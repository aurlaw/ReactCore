using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PuppeteerSharp;
using ReactCore.Models;

namespace ReactCore.Controllers
{
    [Route("/api/{controller}")]
    public class PuppeteerController : Controller
    {
        private readonly IWebHostEnvironment env;

        public PuppeteerController(IWebHostEnvironment environment) 
        {
            env = environment;    
        }
        // [HttpGet]
        // public IActionResult Capture() 
        // {
        //     return Ok(new {
        //         message = "Testing"
        //     });            
        // }
        public async Task<IActionResult> Index()
        {
            // var d = new Demo();
            // var demo = await this.RenderViewToStringAsync("/Views/Home/Demo.cshtml", d);
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var host = Request.Host;
            var scheme  = Request.Scheme;
            var urlHost = $"{scheme}://{host.Host}:{host.Port}";
            if (env.IsDevelopment()) {
                urlHost = "http://localhost:8020";
            }
            var page = await browser.NewPageAsync();
            await page.GoToAsync($"{urlHost}/Home/demo");
            var demoData = await page.ScreenshotBase64Async(new ScreenshotOptions{Type= ScreenshotType.Jpeg, Quality= 100});

            return Ok(new {
                message = demoData,
                scheme = scheme,
                host = host.Host,
                Port = host.Port,
                urlHost = urlHost
            }); 
        }

    }
}