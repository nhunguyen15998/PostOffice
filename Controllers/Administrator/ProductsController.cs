using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class ProductsController : Controller
    {
        public static int id = 0;
        List<AttributeModel> m = new List<AttributeModel>();
        List<ProductModel> lp = new List<ProductModel>();
        List<ProductAttributeModel> la = new List<ProductAttributeModel>();

        IProductService _Productsvc = null;
        IAttributeService _attrsvc = null;
        IProductCategoryService _pdcatesvc = null;
        public ProductsController(IProductService ProductProduct, IAttributeService attr, IProductCategoryService pdcate)

        {
            _attrsvc = attr;
            _pdcatesvc = pdcate;
            _Productsvc = ProductProduct;
        }
        public IActionResult Index()
        {
            ViewBag.pd = _Productsvc;
            ViewBag.pdcate = _pdcatesvc;
            ViewBag.lsCate = _pdcatesvc.GetListProductCategory();
            ViewBag.ls_status = ProductModel.ls_status;
            m = _attrsvc.GetListAttribute();
            lp = _Productsvc.GetListProduct();
            la = _Productsvc.GetListProductAttribute();
            return View();
        }
        public string GetListAttribute(int id)
        {
            var q= m.Where(x=>x.type==id).ToList();
            var res = $"<option value='-1'>--*{AttributeModel.ls_type[id]}*--</option><option value='0'>--NEW--</option>";

            foreach (var item in q)
            {
                res += $"<option value='{item.id}'>{item.name}</option>";
            }
            return res ;
        }
        public bool CheckExistsName(string name, int type)
        {
            return m.FirstOrDefault(x => x.name.ToLower() == name.ToLower() && x.type == type) == null ? false : true;
        }
        public AttributeModel SaveAttribute(AttributeModel mdl)
        {
            _attrsvc.SaveAttribute(mdl);
            return mdl;
        }
        public void SaveProduct(string mdl, string lsAttr)
        {
           
            ProductModel p = JsonConvert.DeserializeObject<ProductModel>(mdl);
            List<ProductAttributeModel> ls = JsonConvert.DeserializeObject<List<ProductAttributeModel>>(lsAttr);
           
            
            
            if (ls.Count==0)
                _Productsvc.SaveProduct(new ProductModel() { id = 1, categoryId = p.categoryId, code = Helpers.Helpers.RandomCode(), createdAt = DateTime.Now, description = p.description, name = p.name, price = p.price });


            foreach (var item in ls)
            {
                _Productsvc.SaveProductAttribute(new ProductAttributeModel() { qty=item.qty,colorID = item.colorID, heightID = item.heightID, lengthID = item.lengthID, widthID = item.widthID, createAt = DateTime.Now, price = item.price, productId = item.productId });
            }
        }
    }
}
