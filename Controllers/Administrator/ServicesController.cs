using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class ServicesController : Controller
    {
        public static int id = 0;
        IServiceService _Servicesvc = null;
        public ServicesController(IServiceService ServiceService)
        {
            _Servicesvc = ServiceService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public void ServiceCU(ServiceModel model)
        {
            ServiceModel s = model;
        }
    }
}
