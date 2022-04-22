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
        public IServiceService _serviceService;
        public ServiceController(ILogger<ServiceController> logger, IServiceService serviceService)
        {
            _logger = logger;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<ServiceModel> GetServiceList([FromQuery] int serviceId)
        {
            return _serviceService.GetService(serviceId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
