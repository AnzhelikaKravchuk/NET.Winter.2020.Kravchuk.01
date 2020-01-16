using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Hello(string userName)
        {
            ViewBag.Answer = StringManipulation.Greeting.SayHello(userName);

            return View("Answer");
        }
    }
}