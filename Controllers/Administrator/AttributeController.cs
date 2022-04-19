using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;
using System.Diagnostics;

namespace post_office.Controllers.Administrator
{
    public class AttributeController : Controller
    {
        public static int id = 0;
        IAttributeService _attrsvc = null;
        public static List<AttributeModel> ls_attr = new List<AttributeModel>();
        public AttributeController(IAttributeService attributeService)
        {
            _attrsvc = attributeService;
        }
        public IActionResult Index()
        {
            ViewBag.ls_attr=ls_attr = _attrsvc.GetListAttribute();
            ViewBag.attr = AttributeModel.ls_type;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AttributeCU(AttributeModel model)
        {
            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    model.id = id;
                    _attrsvc.ModifyAttribute(model);
                    id = 0;
                }
                else _attrsvc.SaveAttribute(model);
            }

            ModelState.Clear();
            return RedirectToAction("Index");

        }
        //NameAttrExists
        public JsonResult NameAttrExists(AttributeModel model)
        {
            var obj = ls_attr.FirstOrDefault(x => x.name.ToLower() == model.name.ToLower()&&model.type==0?true: x.type ==model.type);
            if (id != 0 && obj != null) { obj = obj.id != id ? obj : null; }
            return Json(obj == null ? true : false);
        }
        public AttributeModel GetAttribute(int id)
        {
            var e = ls_attr.FirstOrDefault(x => x.id == id);
            id = e.id;
            return e;
        }
    }
}

