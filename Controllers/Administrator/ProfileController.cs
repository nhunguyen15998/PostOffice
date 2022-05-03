using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ProfileController : Controller
    {
        private IWebHostEnvironment Environment;

        public static string mess = "";
        IUserService _uSvc = null;
        public ProfileController(IUserService u, IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
            _uSvc = u;
        }
        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                ViewBag.mdl = _uSvc.GetUser(AuthenticetionModel.id);
                return View();
            }
            else return RedirectToAction("Login", "User");
           
        }
        public async Task<bool> UpdateUser(IFormFile file, string mdl)
        {
            UserModel p = JsonConvert.DeserializeObject<UserModel>(mdl);
            UserModel before = _uSvc.GetUser(AuthenticetionModel.id);
            if (p.password != null) before.password = BCrypt.Net.BCrypt.HashPassword(p.password);
            string _Path = this.Environment.WebRootPath + "/img/AvtUser/" + before.avatar;
            if (System.IO.File.Exists(Path.Combine(_Path)) && _Path != string.Empty)  System.IO.File.Delete(Path.Combine(_Path));

            if (file != null)
            {

                string wwwPath = this.Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                before.avatar = fileName = fileName + Helpers.Helpers.RandomCode() + extension;
                AuthenticetionModel.avt = before.avatar;
                string path = Path.Combine(wwwPath + "/img/AvtUser/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

            }
            else { before.avatar = "";
                AuthenticetionModel.avt = "";
            };


            _uSvc.ModifyUser(before, true);
            mess = "Saved successfully~";

            return true;

        }
        public bool CheckOldPass(string old)
        {
            return BCrypt.Net.BCrypt.Verify(old, _uSvc.GetUser(AuthenticetionModel.id).password);
        }
    }
}
