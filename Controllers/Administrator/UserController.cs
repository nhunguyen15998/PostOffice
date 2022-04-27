using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using Newtonsoft.Json;
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
        public static int _id = 0;
        public static string mess = "";
        public static UserModel userCurrent = null;
        IUserService _usersvc = null;
        IRoleService _rolesvc = null;
        IBranchService _branchsvc = null;
        IPermissionService _pmsSvc = null;
        public static List<RoleModel> ls_role = new List<RoleModel>();
        public static List<UserModel> ls_user = new List<UserModel>();
        public static List<BranchModel> ls_branch = new List<BranchModel>();
        public static VerifyModel verify = new VerifyModel();

        public UserController(IUserService userService, IBranchService branchService, IRoleService roleService, IPermissionService psm)
        {
            _usersvc = userService;
            _branchsvc = branchService;
            _rolesvc = roleService;
            _pmsSvc = psm;
           
        }
        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                ViewBag.ls_user = ls_user = _usersvc.GetListUser();
                ViewBag.role_ls = new SelectList(_rolesvc.GetListRole(), "id", "name");
                ViewBag.branch_ls = new SelectList(_rolesvc.GetListRole(), "id", "name");
                ViewBag.ls_sts = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };
                return View();

            }
            else return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            if (AuthenticetionModel.id != 0) return RedirectToAction("Dashboard", "Auth");
            return View();
        }
        [HttpPost]
        public IActionResult LoginAction()
        {
            string uName = Request.Form["username"];
            string psw = Request.Form["psw"];
            UserModel u = _usersvc.LoginAction(uName, psw);
            if (u is null)
            {
                TempData["ErrorLogin"] = "Invalid login, please try again";
                TempData["user"] = uName;
                TempData["pass"] = psw;
                return RedirectToAction("Login");
            }
            else
            {
                AuthenticetionModel.SetCurrent(u.id, u.roleId, u.fullName, _rolesvc.GetRole(u.roleId).name, u.branchId, u.branchId == 0 ? "" : _branchsvc.GetBranch(u.branchId).name, u.avatar, _pmsSvc.GetListPermissionByRoleID(u.roleId));
          
            }
            return RedirectToAction("Dashboard","Auth");
        }
        public IActionResult LogoutAction()
        {
            AuthenticetionModel.ClearSession();
            return RedirectToAction("Login");
        }

        /*VERIFY*/
        //type: 0:set up new pass, 1: verify pass
        public IActionResult VerifyUser(int type, bool send=true) {
            if (userCurrent == null) return RedirectToAction("Login");
            if (send)
            {
                verify = null;
                verify=Helpers.Helpers.SendVerifyCode(userCurrent.email,userCurrent.fullName, true, true);
                ViewBag.data = $"We have just sent the verification code to the email {userCurrent.email.Substring(0, 6)}******* of the account with the phone number {userCurrent.phone} to confirm, please check your email.";

            }

            return View(type);
        }
       
        public IActionResult VerifyAction()
        {

            string code = Request.Form["verify_code"];
            if (verify.verify_code == code && verify.email == userCurrent.email && verify.created_at.AddMinutes(5)>= DateTime.Now&&verify.isForUser)
            {
                return RedirectToAction("VerifyUser", new { type = 1, send = false });

            }
            TempData["ErrorVerifyUser"] = "The confirmation code is not valid or overdue, please try again";
            return RedirectToAction("VerifyUser", new {type=0, send=false });
        }
        public void SetUpNewPass(string newpass)
        {
            UserModel mdl = userCurrent;
            mdl.password = BCrypt.Net.BCrypt.HashPassword(newpass);
            _usersvc.ModifyUser(mdl);
            verify = null;

        }
        public bool CheckPhoneUser(string phone)
        {
            var e = _usersvc.GetListUser().FirstOrDefault(x => x.phone == phone);
            if (e == null) return false;
            else { userCurrent = e; return true; }
        }
        /*==============END VERIFY==============*/
        /*RUD*/
        public IActionResult UserCU(UserModel mdl)
        {
            if (_id != 0)
            {
                mdl.id = _id;
                _usersvc.ModifyUser(mdl);
                _id = 0;
            }
            else _usersvc.SaveUser(mdl);
            mess = "Saved successfully!";

            return RedirectToAction("Index");
        }
    }
}
