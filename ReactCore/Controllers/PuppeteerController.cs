using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PuppeteerSharp;
using ReactCore.Models;
using ReactCore.Services;
namespace ReactCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuppeteerController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ICaptureService _captureService;

        public PuppeteerController(IWebHostEnvironment environment, ICaptureService captureService) 
        {
            env = environment;    
            _captureService = captureService;
        }

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Index(string id)
        {
            var result = await _captureService.TestAsync(id);
            return Ok(new {
                message = result
            });  
        }
        [HttpPost("capture")]
        [ProducesResponseType(200)]
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

    }


}