using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ServiceController : Controller
    {
        public static int id = 0;

        public void ServiceCU(ServiceModel model)
        {
            ServiceModel s = model;
        }
    }
}
