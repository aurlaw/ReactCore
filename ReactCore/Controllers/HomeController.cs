using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactCore.Models;

namespace ReactCore.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("/[action]")]
        public IActionResult WebWorker() 
        {
            return View();
        }
        [HttpGet("/[action]")]
        public IActionResult Animation() 
        {
            return View();
        }
        [HttpGet("/[action]")]
        public IActionResult Generator() 
        {
            return View();
        }
        [HttpGet("/[action]")]
        public IActionResult Demo([FromQuery] string m) 
        {
            var d = new DemoModel{Message = m};
            return View(d);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
