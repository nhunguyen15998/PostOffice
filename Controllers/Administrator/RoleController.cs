﻿using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class RoleController : Controller
    {
        //parameters
        public static int roleId = 0;
        public static int page = 1;
        public static string mess = string.Empty;
        public static List<int> before = new List<int>();
        public static IRoleService _rolesvc = null;
        public static IPermissionService _pmsSvc = null;
        public static List<RolePermissionModel> ls_role_pms = new List<RolePermissionModel>() ;
        public static List<RoleModel> ls = new List<RoleModel>();
        public static List<PermissionModel> ls_pms = new List<PermissionModel>();


        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                ls_role_pms = _rolesvc.GetListRolePermission();
                ls = LoadDataRole(page, string.Empty);
                ViewBag.pagi = RowEvent(_rolesvc.GetListRole().Count);
                ls_pms = _rolesvc.GetListPermission();
                ViewBag.lsRole = ls;

                return View();
            }
            else return RedirectToAction("Login", "User");
           
        }
        public RoleController(IRoleService roleService, IPermissionService permissionService)
        {
            _rolesvc = roleService;
            _pmsSvc = permissionService;


        }
      

        public JsonResult CodeRoleExists(RoleModel model)
        {
            var obj = _rolesvc.GetListRole().FirstOrDefault(x => x.code.ToLower() == model.code.ToLower());
            if (roleId != 0 && obj != null) { obj = obj.id != roleId ? obj : null; }
            return Json(obj == null ? true : false);

        }
        public JsonResult NameRoleExists(RoleModel model)
        {
            var obj = _rolesvc.GetListRole().FirstOrDefault(x => x.name.ToLower() == model.name.ToLower());
            
            if (roleId != 0 && obj!=null) { obj = obj.id != roleId ? obj : null; }
            return Json(obj == null ? true : false);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RoleCU(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                if (roleId != 0)
                {
                    model.id = roleId;
                    _rolesvc.ModifyRole(model);
                    roleId = 0;

                }
                else _rolesvc.SaveRole(model);
                mess = "Saved successfully!";
            }

            ModelState.Clear();
            return RedirectToAction("Index");
        }
        public void DeleteRole(List<int> ls)
        {
            bool delete = _rolesvc.RemoveRole(ls);
            mess = "Deleted successfully!";
            if (!delete)
                mess = (ls.Count == 1 ? "Item" : "There are some items that") + " cannot be deleted. Please make sure the item you delete is not a role of another user";

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
            List<PermissionModel> lsPermission = ls_pms.Where(x =>type==true? !before.Contains(x.id): before.Contains(x.id)).OrderBy(x=>x.name).ToList();
    
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
                    _rolesvc.RemoveRolePermission(item);
                }
            }
            else
            {
                foreach (var item in insert)
                {
                   _rolesvc.CreateRolePermission(new RolePermissionModel() {roleId=roleId, pmsId=item, createdAt=DateTime.Now});
                }
                foreach (var item in delete)
                {
                    _rolesvc.RemoveRolePermission(item);


                }
            }
            AuthenticetionModel.permissions = _pmsSvc.GetListPermissionByRoleID(AuthenticetionModel.roleId);
            mess = "Saved successfully!";
            roleId = 0;
        }
        //Pagination
        public List<RoleModel> LoadDataRole(int p, string cond)
        {
            int currentSkip = 10 * (p - 1);
            var w = _rolesvc.GetListRole().Where(x => x.name.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.code.ToLower().Contains(cond == null ? "" : cond.ToLower())).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
            return w;
        }
        public int GetCountRole(string cond)
        {
           return _rolesvc.GetListRole().Where(x => x.name.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.code.ToLower().Contains(cond == null ? "" : cond.ToLower())).ToList().Count;

        }
        public int RowEvent(int i)
        {
            double pagi = i / 10.0;
            if (Helpers.Helpers.IsNumber(pagi.ToString()))
            {
                pagi = (int)pagi;
                pagi += 1;
            }
            return (int)pagi;
        }
        //End pagination

    }
}
