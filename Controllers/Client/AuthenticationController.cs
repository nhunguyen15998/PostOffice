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

namespace post_office.Controllers.Client
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private ICustomerService _customerService;
        private readonly AppSettings _appSettings;

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

        [TempData]
        public string Message { get; set; }
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
