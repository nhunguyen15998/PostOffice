using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class RoleController : Controller
    {
        public static int roleId = 0;
        public static List<int> before = new List<int>();

        public static List<RolePermissionModel> ls_role_pms= new List<RolePermissionModel>(){
            new RolePermissionModel() {id=1, roleId=2, pmsId=1, createdAt=DateTime.Now },
            new RolePermissionModel() {id=2, roleId=2, pmsId=2, createdAt=DateTime.Now },
            new RolePermissionModel() {id=3, roleId=2, pmsId=3, createdAt=DateTime.Now },
            new RolePermissionModel() {id=4, roleId=2, pmsId=4, createdAt=DateTime.Now },
            new RolePermissionModel() {id=5, roleId=2, pmsId=5, createdAt=DateTime.Now },
            new RolePermissionModel() {id=6, roleId=2, pmsId=6, createdAt=DateTime.Now },
            new RolePermissionModel() {id=7, roleId=2, pmsId=7, createdAt=DateTime.Now },
            new RolePermissionModel() {id=8, roleId=2, pmsId=8, createdAt=DateTime.Now }};

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
        public void GetListPermision(int rID)
        {
            before = ls_role_pms.Where(x => x.roleId == rID).Select(x => x.pmsId).ToList();
           

        }
        public List<PermissionModel> RenderListPermission(bool type)
        {
            //true: left,  false: current

            List<PermissionModel> lsPermission = PermissionController.lsPms.Where(x =>type==true? !before.Contains(x.id): before.Contains(x.id)).ToList();
    
            return lsPermission;
            
        }
        public void UpdatePermission(string af)
        {
            List<int> after= JsonConvert.DeserializeObject<List<int>>(af);
            List<int> insert = after.Except(before).ToList();
            List<int> delete = before.Except(after).ToList();
            if (after.Count == 0)
            {
                foreach (var item in before)
                {
                    ls_role_pms.Remove(ls_role_pms.FirstOrDefault(x=>x.pmsId==item));
                }
            }
            else
            {
                foreach (var item in insert)
                {
                    ls_role_pms.Add(new RolePermissionModel() {id=ls_role_pms[ls_role_pms.Count-1].id+1,roleId=roleId, pmsId=item, createdAt=DateTime.Now});
                }
                foreach (var item in delete)
                {
                    ls_role_pms.Remove(ls_role_pms.FirstOrDefault(x => x.pmsId == item));

                }
            }
        }
    }
}
