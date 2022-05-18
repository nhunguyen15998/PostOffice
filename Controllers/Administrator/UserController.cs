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
        public static int page = 1;
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
            if (AuthenticetionModel.id != 0&& AuthenticetionModel.hasPermission("VIEW_USER"))
            {
                ViewBag.ls_user = ls_user = LoadDataUser(page, string.Empty,0,0);
                ViewBag.pagi = RowEvent(_usersvc.GetListUser().Count);
                ViewBag.branch_ls = new SelectList(_rolesvc.GetListRole(), "id", "name");
                ViewBag.ls_sts = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };
                ViewBag.role_search = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "Select role" } }.Concat(new SelectList(AuthenticetionModel.roleName == "Super Admin" ? _rolesvc.GetListRole() : _rolesvc.GetListRole().Where(x => x.name != "Super Admin"), "id", "name"));
                ViewBag.branchList = new List<SelectListItem> { new SelectListItem { Text = "Select branch", Value = "0" } }.Concat(new SelectList(_branchsvc.GetListBranch().Where(x => x.status == 1).ToList(), "id", "name"));
                
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
            return RedirectToAction("Dashboard", "Auth");
        }
        public IActionResult LogoutAction()
        {
            AuthenticetionModel.ClearSession();
            return RedirectToAction("Login");
        }

        /*VERIFY*/
        //type: 0:set up new pass, 1: verify pass
        public IActionResult VerifyUser(int type, bool send = true) {
            if (userCurrent == null) return RedirectToAction("Login");
            if (send)
            {
                verify = null;
                verify = Helpers.Helpers.SendVerifyCode(userCurrent.email, userCurrent.fullName, true, true);
                ViewBag.data = $"We have just sent the verification code to the email {userCurrent.email.Substring(0, 6)}******* of the account with the phone number {userCurrent.phone} to confirm, please check your email.";

            }

            return View(type);
        }
        public bool hasPermission(string code)
        {
            return AuthenticetionModel.hasPermission(code);
        }
        public IActionResult VerifyAction()
        {

            string code = Request.Form["verify_code"];
            if (verify.verify_code == code && verify.email == userCurrent.email && verify.created_at.AddMinutes(5) >= DateTime.Now && verify.isForUser)
            {
                return RedirectToAction("VerifyUser", new { type = 1, send = false });

            }
            TempData["ErrorVerifyUser"] = "The confirmation code is not valid or overdue, please try again";
            return RedirectToAction("VerifyUser", new { type = 0, send = false });
        }
        public void SetUpNewPass(string newpass)
        {
            UserModel mdl = userCurrent;
            mdl.password = BCrypt.Net.BCrypt.HashPassword(newpass);
            _usersvc.ModifyUser(mdl,true);
            verify = null;

        }
        //checkdup
        public JsonResult PhoneUserExists(UserModel model)
        {
            var obj = _usersvc.GetListUser().FirstOrDefault(x => x.phone == model.phone);
            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);

        }
        public JsonResult EmailUserExists(UserModel model)
        {
            var obj = _usersvc.GetListUser().FirstOrDefault(x => x.email==model.email);

            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);
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
            bool check = true;
            if (_id != 0)
            {
                mdl.id = _id;
                check=_usersvc.ModifyUser(mdl,false);
                _id = 0;
            }
            else _usersvc.SaveUser(mdl);
            if (check)
                mess = "Saved successfully!";
            else mess = "You cannot deactivate yourself.";

            return RedirectToAction("Index");
        }
        public UserModel GetUser(int id)
        {
            var u = _usersvc.GetUser(id);
            _id = u.id;
            return u;
        }
        public void ChangeStatusUser(List<int> ls, int status)
        {
            bool changeStatus=_usersvc.ChangeStatusListUser(ls, status);
            mess = "Saved successfully!";
            if (!changeStatus)
                mess = (ls.Count == 1 ? "Item" : "There are some items that") + " cannot deactivated. Please make sure item you choose is not your account";

        }
        //Pagination
        public List<UserModel> LoadDataUser(int p, string cond, int type, int branchId)
        {
            int currentSkip = 10 * (p - 1);
            var w = _usersvc.GetListUser().Where(x => (x.fullName.ToLower().Contains(cond == null ? "" : cond.ToLower())|| x.code.ToLower().Contains(cond == null ? "" : cond.ToLower())|| x.email.ToLower().Contains(cond == null ? "" : cond.ToLower())|| x.phone.Contains(cond == null ? "" : cond))
                                                                             && (type == 0 ? true : x.roleId == type)
                                                                             && (branchId == 0 ? true:x.branchId == branchId)&&((AuthenticetionModel.roleName=="Super Admin")?true:x.branchId==AuthenticetionModel.branchId)).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
            return w;
        }
        public int GetCountUser(int parent, string cond, int type, int branchId)
        {
            return _usersvc.GetListUser().Where(x => (x.fullName.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.code.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.email.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.phone.ToLower().Contains(cond == null ? "" : cond.ToLower()))
                                                                             && (type == 0 ? true : x.roleId == type)
                                                                             && (branchId == 0 ? true : x.branchId == branchId)&&((AuthenticetionModel.roleName == "Super Admin") ? true : x.branchId == AuthenticetionModel.branchId)).ToList().Count;

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
