using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class SettingFeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
