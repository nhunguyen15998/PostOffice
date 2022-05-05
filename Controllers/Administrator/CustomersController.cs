using Microsoft.AspNetCore.Mvc;
using post_office.Entities;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class CustomersController : Controller
    {
        public static int _id = 0;
        public static int page = 1;
        public static string mess = "";
        ICustomerService _cusSvc = null;
        public CustomersController(ICustomerService customerService)
        {
            _cusSvc = customerService;
        }
        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                ViewBag.lsCus = LoadDataCustomer(page, string.Empty, -1);
                ViewBag.pagi = RowEvent(_cusSvc.GetListCustomer().Count);
                ViewBag.lsSTS = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };

                return View();
            }
            else return RedirectToAction("Login", "User");
        }
       
        public IActionResult CustomerUpdate( CustomerModel cus)
        {
            cus.Id = _id;
            _cusSvc.ModifyCustomer(cus);
            _id = 0;
            mess = "Saved successfully!";
            return RedirectToAction("Index");
        }
        public CustomerModel GetCustomer(int id)
        {
            var w = _cusSvc.GetCustomer(id);
            _id = w.Id;
            return w;
        }
        //Pagination
        public List<CustomerModel> LoadDataCustomer(int p, string cond, int status)
        {
            int currentSkip = 10 * (p - 1);
            var w = _cusSvc.GetListCustomer().Where(x => (x.FirstName.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.LastName.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.Email.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.Phone.Contains(cond == null ? "" : cond))
                                                                             && (status==-1?true:x.Status==status)).OrderByDescending(x => x.Id).Skip(currentSkip).Take(10).ToList();
            return w;
        }
        public int GetCountCustomer( string cond, int status)
        {
            return _cusSvc.GetListCustomer().Where(x => (x.FirstName.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.LastName.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.Email.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.Phone.Contains(cond == null ? "" : cond))
                                                                             && (status == -1 ? true : x.Status == status)).ToList().Count;

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
