using System.Threading.Tasks;

namespace GrpcService.Services
{
    public interface IScreenService
    {
         Task<string> GetScreenshot(string url);
    }
}