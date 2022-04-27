using Microsoft.AspNetCore.Mvc;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                
                return View();
            }
            else return RedirectToAction("Login", "User");
        }
    }
}
