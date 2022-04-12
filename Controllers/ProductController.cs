using epjSem3.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Controllers
{
    public class ProductController : Controller
    {
        public static int id = 0;
        List<AttributeModel> m = new List<AttributeModel>() {
                new AttributeModel() { id = 1, createdAt = DateTime.Now, name = "red", type = 1, typeName = "color" },
                new AttributeModel() { id = 2, createdAt = DateTime.Now, name = "pink", type = 1, typeName = "color" },
                new AttributeModel() { id = 3, createdAt = DateTime.Now, name = "blue", type = 1, typeName = "color" },
                new AttributeModel() { id = 4, createdAt = DateTime.Now, name = "S", type = 2, typeName = "size" },
                new AttributeModel() { id = 5, createdAt = DateTime.Now, name = "M", type = 2, typeName = "size" },
                new AttributeModel() { id = 6, createdAt = DateTime.Now, name = "L", type = 2, typeName = "size" },
                new AttributeModel() { id = 7, createdAt = DateTime.Now, name = "10", type = 3, typeName = "width" },
                new AttributeModel() { id = 8, createdAt = DateTime.Now, name = "30", type = 3, typeName = "width" },
                new AttributeModel() { id = 9, createdAt = DateTime.Now, name = "20", type = 4, typeName = "height" },
                new AttributeModel() { id = 10, createdAt = DateTime.Now, name = "20", type = 4, typeName = "height" }};
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
            m.Add(new AttributeModel() { id = 11, createdAt = DateTime.Now, name = mdl.name, type = mdl.type, typeName = mdl.type == 1 ? "color" : (mdl.type == 2 ? "size" : (mdl.type == 3 ? "width" : "height")) });
            return m[m.Count - 1];
        }
    }
}
