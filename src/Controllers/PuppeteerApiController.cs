using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactCore.Models;

namespace ReactCore.Controllers
{
    [Route("api/puppeteer")]
    public class PuppeteerApiController : Controller
    {
        [HttpGet]
        public IActionResult ListProducts() 
        {
            return Ok(new {
                message = "Testing"
            });            
        }
    }
}