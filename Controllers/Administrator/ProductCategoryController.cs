using Microsoft.AspNetCore.Mvc;
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
        public ProductCategoryController(IProductCategoryService productCategory)
        {
            _ProductCategorysvc = productCategory;
        }
        public IActionResult Index()
        {
            /*ViewBag.lsPDCate = ProductCategoryModel.ls_status;*/
            return View();
        }
    }
}
