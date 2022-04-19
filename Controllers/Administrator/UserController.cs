using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class UserController : Controller
    {
        public static int id = 0;
        IUserService _usersvc = null;
        IRoleService _rolesvc = null;
        IBranchService _branchsvc = null;
        public static List<RoleModel> ls_role = new List<RoleModel>();
        public static List<BranchModel> ls_branch = new List<BranchModel>();
        public UserController(IUserService userService, IBranchService branchService, IRoleService roleService)
        {
            _usersvc = userService;
            _branchsvc = branchService;
            _rolesvc = roleService;
           
        }
        public IActionResult Index()
        {
            ViewBag.role_ls = new SelectList(_rolesvc.GetListRole(), "id", "name");
            ViewBag.branch_ls = new SelectList(_rolesvc.GetListRole(), "id", "name");
            ViewBag.ls_sts = UserModel.ls_sts;
            return View();
        }
    }
}
