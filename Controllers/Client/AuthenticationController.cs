using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using Microsoft.AspNetCore.Authorization;
using post_office.Services;
using post_office.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace post_office.Controllers.Client
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private ICustomerService _customerService;
        private readonly AppSettings _appSettings;
        public static VerifyModel verify = new VerifyModel();
        public static CustomerModel customerCurrent = null;
        public static bool hasSetUp = false;
        [TempData]
        public string Message { get; set; }

        public AuthenticationController(ILogger<AuthenticationController> logger, 
        ICustomerService customerService, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _customerService = customerService;
            _appSettings = appSettings.Value;
        }

        public IActionResult SignUp()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerPhone")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult VerifyAccount(int setup,int type, bool send = true)
        {
            if (setup == 1) hasSetUp=true; 
            else hasSetUp=false;
            

            if (customerCurrent == null) return RedirectToAction("SignIn");
                if (send)
                {
                    verify = null;
                    verify = Helpers.Helpers.SendVerifyCode(customerCurrent.Email, customerCurrent.FirstName+" "+customerCurrent.LastName, false, true);
                    ViewBag.data = $"We have just sent the verification code to the email {customerCurrent.Email.Substring(0, 6)}******* of the account with the phone number {customerCurrent.Phone} to confirm, please check your email.";

                }

                return View(type);
        }
        public IActionResult VerifyAction()
        {

            string code = Request.Form["verify_code"];
            if (verify.verify_code == code && verify.email == customerCurrent.Email && verify.created_at.AddMinutes(5) >= DateTime.Now && !verify.isForUser)
            {
                if (hasSetUp) {
                    //update status customer to activated here
                    customerCurrent.Status = 1;
                    _customerService.ModifyCustomer(customerCurrent);
                    return RedirectToAction("SignIn");
                        }

                return RedirectToAction("VerifyAccount", new { type = 1, send = false });

            }
            TempData["ErrorVerifyUser"] = "The confirmation code is not valid or overdue, please try again";
            return RedirectToAction("VerifyAccount", new { type = 0, send = false });
        }
        public void SetUpNewPass(string newpass)
        {
            CustomerModel mdl = customerCurrent;
            mdl.Password = BCrypt.Net.BCrypt.HashPassword(newpass);
            _customerService.ModifyCustomer(mdl);
            verify = null;
        }
        public bool CheckPhoneCustomer(string phone)
        {
            var e = _customerService.GetListCustomer().FirstOrDefault(x => x.Phone == phone);
            if (e == null) return false;
            else { customerCurrent = e; return true; }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(){
            try {
                var firstName = Request.Form["first-name"].ToString();
                var lastName = Request.Form["last-name"].ToString();
                var phone = Request.Form["phone"].ToString();
                var email = Request.Form["email"].ToString();
                var password = Request.Form["password"].ToString();
                if (string.IsNullOrWhiteSpace(password))
                    throw new AppException("Password is required");

                var customer = new {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    CreatedAt = DateTime.Now,
                    Status = (int)Helpers.Helpers.DefaultStatus.Deactivated
                };

                int customerId = _customerService.Create(customer, phone).Id;
                if(customerId != 0){
                    Message = "Successfully registered";
                    return RedirectToAction("SignIn", "Authentication");   
                }
                Message = "Oops! Something went wrong";
                return RedirectToAction("SignUp", "Authentication");
            } catch(Exception ex) {
                return BadRequest(new { Message = ex.Message });
            }

        }

        public IActionResult SignIn()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerPhone")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authenticate(){
            try{
                var phone = Request.Form["sign-in-phone"];
                var password = Request.Form["sign-in-password"];
                if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
                    throw new AppException("Password is required");
                var customer = _customerService.Authenticate(phone, password);
                if (customer == null)
                    return BadRequest(new { message = "Phone or password is incorrect" });

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("CustomerPhone")))
                {
                    HttpContext.Session.SetInt32("CustomerId", customer.Id);
                    HttpContext.Session.SetString("CustomerPhone", customer.Phone);
                    if(customer.Avatar != null){
                        HttpContext.Session.SetString("CustomerAvatar", customer.Avatar);
                    }
                    HttpContext.Session.SetString("CustomerEmail", customer.Email);
                    HttpContext.Session.SetString("CustomerName", customer.FirstName+" "+customer.LastName);
                }
                // var name = HttpContext.Session.GetString("CustomerName");
                // var age = HttpContext.Session.GetInt32(SessionKeyAge).ToString();

                // _logger.LogInformation("Session Name: {Name}", name);
                // _logger.LogInformation("Session Age: {Age}", age);
                // return basic user info and authentication token
                return RedirectToAction("Index", "Home");
            }catch(Exception ex){
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SignOutAction()
        {
            try {
                HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
