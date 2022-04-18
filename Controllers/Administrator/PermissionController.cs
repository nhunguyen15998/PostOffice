using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class PermissionController : Controller
    {
        public static IPermissionService _Permissionsvc = null;

        public static List<PermissionModel> lsPms = new List<PermissionModel>();
        
        public PermissionController(IPermissionService permissionService)
        {
            lsPms = _Permissionsvc.GetListPermission();
            _Permissionsvc = permissionService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}