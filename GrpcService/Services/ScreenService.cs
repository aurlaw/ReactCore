using PuppeteerSharp;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class ScreenService : IScreenService
    {
        public async Task<string> GetScreenshot(string url) 
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            return await page.ScreenshotBase64Async(new ScreenshotOptions{Type= ScreenshotType.Jpeg, Quality= 100});
        }
    }
}