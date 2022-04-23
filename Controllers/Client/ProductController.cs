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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        public ProductController(ILogger<ProductController> logger, 
               IProductCategoryService productCategoryService, 
               IProductService productService)
        {
            _logger = logger;
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        //pickup -product
        [HttpGet]
        public List<ProductCategoryModel> GetProductCategoryByParent([FromQuery] int parentId)
        {
            return _productCategoryService.GetParentCategories(parentId);
        }

        [HttpGet]
        public List<ProductModel> GetProductsByPCate([FromQuery] int categoryId)
        {
            var a = _productService.GetListProduct(categoryId, 1);
            return a;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
