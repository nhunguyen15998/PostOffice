using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ProductController : Controller
    {
        public static int id = 0;
        List<AttributeModel> m = new List<AttributeModel>() {
                new AttributeModel() { id = 1, createdAt = DateTime.Now, name = "red", type = 1},
                new AttributeModel() { id = 2, createdAt = DateTime.Now, name = "pink", type = 1 },
                new AttributeModel() { id = 3, createdAt = DateTime.Now, name = "blue", type = 1},
                new AttributeModel() { id = 4, createdAt = DateTime.Now, name = "S", type = 2 },
                new AttributeModel() { id = 5, createdAt = DateTime.Now, name = "M", type = 2 },
                new AttributeModel() { id = 6, createdAt = DateTime.Now, name = "L", type = 2 },
                new AttributeModel() { id = 7, createdAt = DateTime.Now, name = "10", type = 3 },
                new AttributeModel() { id = 8, createdAt = DateTime.Now, name = "30", type = 3},
                new AttributeModel() { id = 9, createdAt = DateTime.Now, name = "20", type = 4},
                new AttributeModel() { id = 10, createdAt = DateTime.Now, name = "40", type = 4 }};
        public IActionResult Index()
        {
            return View();
        }
        public string GetListAttribute(int id)
        {
            var q= m.Where(x=>x.type==id).ToList();
            var res = $"<option value='-1'>--*{q.FirstOrDefault(x => x.type == id).typeName}*--</option><option value='0'>--NEW--</option>";

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
            m.Add(new AttributeModel() { id = 11, createdAt = DateTime.Now, name = mdl.name, type = mdl.type});
            return m[m.Count - 1];
        }
        public void SaveProduct(string mdl, string lsAttr)
        {
            List<ProductModel> lp = new List<ProductModel>();
            List<ProductAttributeModel> la = new List<ProductAttributeModel>();
            ProductModel p = JsonConvert.DeserializeObject<ProductModel>(mdl);
            List<ProductAttributeModel> ls = JsonConvert.DeserializeObject<List<ProductAttributeModel>>(lsAttr);
            lp.Add(new ProductModel() { id = 1, categoryId = p.categoryId, code = Helpers.Helpers.RandomCode(), createdAt = DateTime.Now, description = p.description, name = p.name, price = p.price });
            if (p.price != null|| p.qty != null)
                la.Add(new ProductAttributeModel() { createAt = DateTime.Now, price = (decimal)p.price, productId = p.id, qty=(int)p.qty });
            

            foreach (var item in ls)
            {
                la.Add(new ProductAttributeModel() { qty=item.qty,colorID = item.colorID, heightID = item.heightID, sizeID = item.sizeID, widthID = item.widthID, createAt = DateTime.Now, price = item.price, productId = item.productId });
            }
            Console.WriteLine(lp);
            Console.WriteLine(la);
        }
    }
}
