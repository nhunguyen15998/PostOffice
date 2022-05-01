using Microsoft.AspNetCore.Mvc;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ContactsController : Controller
    {
        public static IContactServices _contactSvc = null;
        public static int page = 1;
        public ContactsController(IContactServices cont)
        {
            _contactSvc = cont;
        }
        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var today = DateTime.Now;
                ViewBag.from = firstDayOfMonth.ToString("yyyy/MM/dd");
                ViewBag.to = today.ToString("yyyy/MM/dd");
                ViewBag.lsContact = LoadDataContact(page, string.Empty, firstDayOfMonth, today, false, false);
                ViewBag.pagi = RowEvent(_contactSvc.GetListContact().Count);

                return View();
            }
            else return RedirectToAction("Login", "User");
           
        }
        //Pagination
        public List<ContactModel> LoadDataContact(int p, string cond, DateTime dateFrom, DateTime dateTo, bool read, bool reply)
        {
            dateTo = dateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddTicks(59);

            int currentSkip = 10 * (p - 1);
            var w = _contactSvc.GetListContact().Where(x => (x.name.ToLower().Contains(cond == null ? "" : cond.ToLower())|| x.phone.Contains(cond == null ? "" : cond)|| x.email.ToLower().Contains(cond == null ? "" : cond.ToLower()))
                                                                             && dateFrom<= x.createdAt.Date&& x.createdAt.Date<dateTo
                                                                             && x.isRead==read&&x.isReply==reply).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
            return w;
        }
        public int GetCountContact(string cond, DateTime dateFrom, DateTime dateTo, bool read, bool reply)
        {
            dateTo = dateTo.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddTicks(59);

            return _contactSvc.GetListContact().Where(x => (x.name.ToLower().Contains(cond == null ? "" : cond.ToLower()) || x.phone.Contains(cond == null ? "" : cond) || x.email.ToLower().Contains(cond == null ? "" : cond.ToLower()))
                                                                             && x.createdAt >= dateFrom.Date && x.createdAt.Date < dateTo
                                                                             && x.isRead == read && x.isReply == reply).ToList().Count;


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
