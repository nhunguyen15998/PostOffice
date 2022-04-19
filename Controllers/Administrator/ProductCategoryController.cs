using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ProductCategoryController : Controller
    {
        public static int id = 0;
        IProductCategoryService _ProductCategorysvc = null;
        public static List<ProductCategoryModel> ls = new List<ProductCategoryModel>();
        public ProductCategoryController(IProductCategoryService productCategory)
        {
            _ProductCategorysvc = productCategory;
        }
        public IActionResult Index()
        {
            ViewBag.lsPDCate=ls = _ProductCategorysvc.GetListProductCategory();
            ViewBag.lsSTS = ProductCategoryModel.ls_status;
            ViewBag.svc = _ProductCategorysvc;
            ViewBag.parent = id == 0 ? new SelectList(_ProductCategorysvc.GetListProductCategory(), "id", "name") : new SelectList(_ProductCategorysvc.GetListProductCategory().Where(x=>x.id!=id), "id", "name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PDCateCU(ProductCategoryModel mdl)
        {
            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    mdl.id = id;
                    //_ProductCategorysvc.SaveProductCategory(mdl);

                }
                else _ProductCategorysvc.SaveProductCategory(mdl);

            }

            ModelState.Clear();
            return RedirectToAction("Index");
        }
        public JsonResult NamePDCateExists(ProductCategoryModel model)
        {
            var obj = ls.FirstOrDefault(x => x.name.ToLower() == model.name.ToLower());

            if (id != 0 && obj != null) { obj = obj.id != id ? obj : null; }
            return Json(obj == null ? true : false);
        }
    }
}
