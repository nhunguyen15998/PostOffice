using epjSem3.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Controllers
{
    public class RoleController : Controller
    {
        public static int roleId = 0;

        public static List<RoleModel> ls = new List<RoleModel>() { new RoleModel() { id = 1, code = "ADMIN", name = "Admin", createdAt = DateTime.Now } ,
        new RoleModel() { id = 2, code = "MANAGER", name = "Manager", createdAt = DateTime.Now } };


        public JsonResult CodeRoleExists(RoleModel model)
        {
            var obj = ls.FirstOrDefault(x => x.code.ToLower() == model.code.ToLower());
            if (roleId != 0) { obj = obj.id != roleId ? obj : null; }
            return Json(obj == null ? true : false);

        }
        public JsonResult NameRoleExists(RoleModel model)
        {
            var obj = ls.FirstOrDefault(x => x.name.ToLower() == model.name.ToLower());
            if (roleId != 0) { obj = obj.id != roleId ? obj : null; }
            return Json(obj == null ? true : false);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void RoleCU(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.code);
                Console.WriteLine(model.name);
            }

            ModelState.Clear();

        }
        public RoleModel GetRole(int id)
        {
            var e = ls.FirstOrDefault(x => x.id == id);
            roleId = e.id;
            return e;
        }
    }
}
