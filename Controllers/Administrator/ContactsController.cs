using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
        public static string mess = "";
        public static int page = 1;
        public static int _id = 0;
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
        public ContactModel GetContact(int id)
        {
            var mdl = new ContactModel { id = id, isRead = true };
            _contactSvc.ModifyContact(mdl);
            var e= _contactSvc.GetContact(id);
            _id = e.id;
            return e;
        }
        public IActionResult ReplyAction()
        {
            string content = Request.Form["content"];
            var contact = _contactSvc.GetContact(_id);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Postal Office", "postaloffice.hcmc@gmail.com"));
            message.To.Add(new MailboxAddress("", contact.email));
            message.Subject = "Feedback for contact: " + contact.subject;
            message.Body = new TextPart("plain")
            {
                Text= $"You have written: {contact.message}\n ____________________________________________________________________________________ \n" +
                      $"Hello {contact.name}, Sincerely thank you for your interest for the Postal Office service.\nRegarding the problem you encounter, we have the following response:\n  {content} \n__\nThanks and Best Regards\nPostal Office Service Team ({AuthenticetionModel.name})"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("postaloffice.hcmc@gmail.com", "Abc123@@");
                client.Send(message);
                client.Disconnect(true);
            }
            var mdl = new ContactModel { id = _id, isRead = true, isReply=true, ReplierId=AuthenticetionModel.id };
            _contactSvc.ModifyContact(mdl);
            _id = 0;
            mess = "Send sucessfully!";
            return RedirectToAction("Index");

        }
    }
}
