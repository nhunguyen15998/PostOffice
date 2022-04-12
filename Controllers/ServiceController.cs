using epjSem3.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Controllers
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
