using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace post_office.Controllers.Administrator
{
    public class ProductsController : Controller
    {
        private IWebHostEnvironment Environment;
        public static int _id = 0;
        public static string mess;
        public static List<AttributeModel> m = new List<AttributeModel>();
        public static List<ProductModel> lp = new List<ProductModel>();
        public static List<ProductAttributeModel> la = new List<ProductAttributeModel>();

        IProductService _Productsvc = null;
        IAttributeService _attrsvc = null;
        IProductCategoryService _pdcatesvc = null;
        public ProductsController(IProductService ProductProduct, IAttributeService attr, IProductCategoryService pdcate, IWebHostEnvironment _environment)

        {
            Environment = _environment;
            _attrsvc = attr;
            _pdcatesvc = pdcate;
            _Productsvc = ProductProduct;
        }
        public IActionResult Index()
        {
            ViewBag.lsPD = _Productsvc.GetListProduct(0,0);
            ViewBag.pd = _Productsvc;
            ViewBag.pdcate = _pdcatesvc;
            ViewBag.ls_status = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };
            m = _attrsvc.GetListAttribute();
            lp = _Productsvc.GetListProduct(0,0);
            la = _Productsvc.GetListProductAttribute(0);
            return View();
        }
        public string GetListAttribute(int id, int type)
        {
            var q = m.Where(x => x.type == id).ToList();
            var res = $"<option value='-1'>--*{AttributeModel.ls_type[id]}*--</option><option value='0'>--NEW--</option>";

            foreach (var item in q)
            {
                if (item.id == type)
                    res += $"<option selected='selected' value='{item.id}'>{item.name}</option>";
                else res += $"<option value='{item.id}'>{item.name}</option>";
            }
            return res;
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
        public async Task<bool> SaveProduct(IFormFile file, string mdl, string lsAttr)
        {
            ProductModel p = JsonConvert.DeserializeObject<ProductModel>(mdl);

            if (file != null)
            {
                string wwwPath = this.Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                p.thumbnail = fileName = fileName + Helpers.Helpers.RandomCode() + extension;
                string path = Path.Combine(wwwPath + "/img/ProductThumbnail/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            if (_id != 0)
            {
                if (file != null)
                {
                    string _Path = this.Environment.WebRootPath + "/img/ProductThumbnail/" + _Productsvc.GetProduct(_id).thumbnail;
                    if (System.IO.File.Exists(Path.Combine(_Path)))
                    {
                        System.IO.File.Delete(Path.Combine(_Path));
                    }

                }
                else
                {
                    p.thumbnail = _Productsvc.GetProduct(_id).thumbnail;
                }
                _Productsvc.RemoveProductAttribute(_id);
                p.id = _id;
                _Productsvc.ModifyProduct(p);
                _id = 0;
            }
            else p = _Productsvc.SaveProduct(new ProductModel() { categoryId = p.categoryId, code = Helpers.Helpers.RandomCode(), createdAt = DateTime.Now, description = p.description, name = p.name, price = p.price, qty = p.qty, status = p.status, thumbnail = p.thumbnail });

            List<ProductAttributeModel> ls = JsonConvert.DeserializeObject<List<ProductAttributeModel>>(lsAttr);
            foreach (var item in ls)
            {
                _Productsvc.SaveProductAttribute(new ProductAttributeModel() { qty = item.qty, colorID = item.colorID, heightID = item.heightID, lengthID = item.lengthID, widthID = item.widthID, createAt = DateTime.Now, price = item.price, productId = p.id });
            }
            mess = "Saved successfully!";
            return true;

        }
        public ProductModel GetProduct(int id)
        {
            var e = lp.FirstOrDefault(x => x.id == id);
            _id = e.id;
            return e;
        }
        public List<ProductAttributeModel> GetProductAttribute(int id)
        {
            return _Productsvc.GetListProductAttribute(0).Where(x => x.productId == id).ToList();

        }
        public string GetCategory(int id)
        {
            return _pdcatesvc.GetProductCategory(id).name;
        }
        public string GetAttributeName(int id)
        {
            return _attrsvc.GetAttribute(id).name;
        }
        public string GetCategoryOption(int id)
        {
            var w = _pdcatesvc.GetListProductCategory();

            string res = "";

            if (id != 0)
            {
                var obj = _pdcatesvc.GetProductCategory(id);
                if (obj != null ? obj.status == 0 : false)
                {
                    res += "<option selected='selected' value=" + obj.id + ">" + obj.name + "</option>";
                }
            }
            foreach (var item in w)
            {
                if (item.status == 1)
                    res += "<option value=" + item.id + ">" + item.name + "</option>";
            }
            return res;
        }



    }
}
