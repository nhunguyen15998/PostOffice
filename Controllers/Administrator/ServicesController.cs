using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class ServicesController : Controller
    {
        public static int _id = 0;
        public static string mess = "";
        IServiceService _Servicesvc = null;
        public static int page = 1;

        public static List<ServiceModel> lsSvc = new List<ServiceModel>();
        public ServicesController(IServiceService ServiceService)
        {
            _Servicesvc = ServiceService;
        }
        public IActionResult Index()
        {
            ViewBag.lsSvc = lsSvc = LoadDataServices(page,string.Empty, -1);
            ViewBag.pagi = RowEvent(_Servicesvc.GetListService().Count);
            ViewBag.ls_status = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ServiceCU(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                if (_id != 0)
                {
                    model.id = _id;
                    _Servicesvc.ModifyService(model);
                    _id = 0;

                }
                else _Servicesvc.SaveService(model);
                mess = "Saved successfully!";
            }

            ModelState.Clear();
            return RedirectToAction("Index");
        }
        //Pagination
        public List<ServiceModel> LoadDataServices(int p,  string name, int status)
        {
            int currentSkip = 10 * (p - 1);
            var w = _Servicesvc.GetListService().Where(x => x.name.ToLower().Contains(name == null ? "" : name.ToLower())|| x.content.ToLower().Contains(name == null ? "" : name.ToLower())
                                                                             && (status == -1 ? true : x.status == status)).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
            return w;
        }
        public int GetCountServices( string name, int status)
        {
            return _Servicesvc.GetListService().Where(x => x.name.ToLower().Contains(name == null ? "" : name.ToLower())|| x.content.ToLower().Contains(name == null ? "" : name.ToLower())
                                                                            && (status == -1 ? true : x.status == status)).OrderByDescending(x => x.id).ToList().Count;


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
        public ServiceModel GetService(int id)
        {
            var w= _Servicesvc.GetService(id);
            _id = w.id;
            return w;
        }
        //NameServiceExists
        public JsonResult NameServiceExists(RoleModel model)
        {
            var obj = lsSvc.FirstOrDefault(x => x.name.ToLower() == model.name.ToLower());
            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);
        }
        //delete
        public void DeleteService(List<int> ls)
        {
            _Servicesvc.RemoveServices(ls);
            mess = "Deleted successfully!";
            
        }
    }
}
