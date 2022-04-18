using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class AttributeController : Controller
    {
        public static int id = 0;
        IAttributeService _attrsvc = null;
        public AttributeController(IAttributeService attributeService)
        {
            _attrsvc = attributeService;
        }
        public IActionResult Index()
        {
            ViewBag.attr = AttributeModel.ls_type;
            _attrsvc.SaveAttribute(new AttributeModel() { name = "red", type = 1 });
            return View();
        }
        public void AttributeCU(AttributeModel model)
        {
            
        }
    }
}

