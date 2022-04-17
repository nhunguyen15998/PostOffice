using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;

namespace post_office.Controllers.Client
{
    public class SendController : Controller
    {
        private readonly ILogger<SendController> _logger;

        public SendController(ILogger<SendController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Views/Send/Pickup.cshtml");
        }

        public IActionResult Tracking()
        {
            return View();
        }

        public IActionResult PinCode()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
