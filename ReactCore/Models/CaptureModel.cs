using Microsoft.AspNetCore.Http;

namespace ReactCore.Models
{
    public class CaptureModel
    {
        public string Message {get;set;}

        public IFormFile FormFile {get; set;}

    }
}