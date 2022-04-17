using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Controllers
{
    public class UserController : Controller
    {
        public static int id = 0;
        public IActionResult Index()
        {

            return View();
        }
    }
}
