using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace post_office.Controllers.Administrator
{
    public class AttributeController : Controller
    {
        public static int _id = 0;
        IAttributeService _attrsvc = null;
        public static List<AttributeModel> ls_attr = new List<AttributeModel>();
        public static string mess=string.Empty;
        public static int page = 1;
        public AttributeController(IAttributeService attributeService)
        {
            _attrsvc = attributeService;
        }
        public IActionResult Index()
        {
            ViewBag.ls_attr=ls_attr = LoadDataAttribute(page, 0, string.Empty);
            ViewBag.attr = AttributeModel.ls_type;
            ViewBag.pagi = RowEvent(_attrsvc.GetListAttribute().Count);
            return View();
        }
        
        public void AttributeCU(string m)
        {
            AttributeModel model = JsonConvert.DeserializeObject<AttributeModel>(m);
           
                if (_id != 0)
                {
                    model.id = _id;
                    _attrsvc.ModifyAttribute(model);
                    _id = 0;
                }
                else _attrsvc.SaveAttribute(model);
                mess = "Saved successfully!";
            


        }
        public void DeleteAttribute(List<int> ls)
        {
            bool delete=_attrsvc.RemoveAttribute(ls);

            mess = "Deleted successfully!";
            if (!delete) mess = (ls.Count == 1 ? "Item" : "There are some items that") + " cannot be deleted.Please make sure that no attribute is used in product";

        }
        //Pagination
        public List<AttributeModel> LoadDataAttribute(int p, int type, string name)
        {
            int currentSkip = 10 * (p - 1);
            return _attrsvc.GetListAttribute().Where(x => x.name.ToLower().Contains(name==null?"":name.ToLower()) && type==0?true:x.type==type).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
           
        }
        public int GetCountAttribute(int type, string name)
        {
            return _attrsvc.GetListAttribute().Where(x => x.name.ToLower().Contains(name == null ? "" : name.ToLower()) && type == 0 ? true : x.type == type).ToList().Count;


        }
        public int RowEvent(int i)
        {

            double pagi = i / 10.0;
            if (Helpers.Helpers.IsNumber(pagi.ToString()))
            {
                pagi = (int)pagi;

                pagi += 1;

            }
            return (int)pagi;
        }
        //End pagination
        //NameAttrExists

        public JsonResult NameAttrExists(string name, int type)
        {
            var obj = ls_attr.FirstOrDefault(x => x.name.ToLower() == name.ToLower()&&x.type ==type);
            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);
        }
        public AttributeModel GetAttribute(int id)
        {
            var e = ls_attr.FirstOrDefault(x => x.id == id);
            _id = e.id;
            return e;
        }
    }
}

