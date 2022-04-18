using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class PermissionController : Controller
    {
        public static List<PermissionModel> lsPms = new List<PermissionModel>() { 
            new PermissionModel() { id=1, code="VIEW_USER",name="View user", createdAt=DateTime.Now },
        new PermissionModel() { id=2, code="UPDATE_USER",name="Update user", createdAt=DateTime.Now },
        new PermissionModel() { id=3, code="DELETE_USER",name="Delete user", createdAt=DateTime.Now },
        new PermissionModel() { id=4, code="VIEW_BRANCH",name="View branch", createdAt=DateTime.Now },
        new PermissionModel() { id=5, code="UPDATE_BRANCH",name="Update branch", createdAt=DateTime.Now },
        new PermissionModel() { id=6, code="DELETE_BRANCH",name="Delete branch", createdAt=DateTime.Now },
        new PermissionModel() { id=7, code="VIEW_PDCATE",name="View product category", createdAt=DateTime.Now },
        new PermissionModel() { id=8, code="UPDATE_PDCATE",name="Update product category", createdAt=DateTime.Now },
        new PermissionModel() { id=9, code="DELETE_PDCATE",name="Delete product category", createdAt=DateTime.Now },
        new PermissionModel() { id=10, code="VIEW_PRODUCT",name="View product", createdAt=DateTime.Now },
        new PermissionModel() { id=11, code="UPDATE_PRODUCT",name="Update product", createdAt=DateTime.Now },
        new PermissionModel() { id=12, code= "DELETE_PRODUCT",name ="Delete product", createdAt=DateTime.Now }};
        public IActionResult Index()
        {
            return View();
        }
    }
}
