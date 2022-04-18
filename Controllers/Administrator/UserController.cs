using Microsoft.AspNetCore.Mvc;
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
        public UserController(IUserService userService)
        {
            _usersvc = userService;
            /* ViewBag.role_ls = new SelectList(ls, "id", "name");
            ViewBag.branch_ls = new SelectList(ls, "id", "name");
            ViewBag.ls_sts = UserModel.ls_sts;*/
        }
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
