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
        public static int id = 0;
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
            ViewBag.lsPD = _Productsvc.GetListProduct();
            ViewBag.pd = _Productsvc;
            ViewBag.pdcate = _pdcatesvc;
            ViewBag.lsCate = new SelectList(_pdcatesvc.GetListProductCategory(), "id", "name");
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
        public async Task<IActionResult> SaveProduct(IFormFile file, string mdl, string lsAttr)
        {
            ProductModel p = JsonConvert.DeserializeObject<ProductModel>(mdl);


            string wwwPath = this.Environment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            p.thumbnail=fileName = fileName + Helpers.Helpers.RandomCode() + extension;
            string path = Path.Combine(wwwPath + "/img/ProductThumbnail/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            List<ProductAttributeModel> ls = JsonConvert.DeserializeObject<List<ProductAttributeModel>>(lsAttr);
            p = _Productsvc.SaveProduct(new ProductModel() { categoryId = p.categoryId, code = Helpers.Helpers.RandomCode(), createdAt = DateTime.Now, description = p.description, name = p.name, price = p.price, qty = p.qty, status = p.status, thumbnail = p.thumbnail });


            foreach (var item in ls)
            {
                _Productsvc.SaveProductAttribute(new ProductAttributeModel() { qty = item.qty, colorID = item.colorID, heightID = item.heightID, lengthID = item.lengthID, widthID = item.widthID, createAt = DateTime.Now, price = item.price, productId = p.id });
            }
            return RedirectToAction("Index");

        }
        public static Image Base64ToImage(string base64String)
        {

            byte[] imageBytes = Convert.FromBase64String(base64String);
            Image image;
            using (MemoryStream inStream = new MemoryStream())
            {
                inStream.Write(imageBytes, 0, imageBytes.Length);
                image = Bitmap.FromStream(inStream);
                image.Save(inStream, image.RawFormat);
            }

            return image;
        }
    }
}
