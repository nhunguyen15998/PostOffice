using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using post_office.Services;

namespace post_office.Controllers.Client
{
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private ILocationService _locationService;

        public ServiceController(ILogger<ServiceController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            ViewBag.Countries = _locationService.GetCountries(DefaultCountries.countryIds);
            return View();
        }

        public IActionResult Detail()
        {
            ViewBag.Countries = _locationService.GetCountries(DefaultCountries.countryIds);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
