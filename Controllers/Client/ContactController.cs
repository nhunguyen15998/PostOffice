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
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        public static IContactServices _contactSvc = null;
        public static string mess = "";
        public ContactController(ILogger<ContactController> logger, IContactServices cont)
        {
            _contactSvc = cont;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendContact(ContactModel mdl)
        {
            _contactSvc.SendMessage(mdl);
            mess = "Sent successfully!";
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
