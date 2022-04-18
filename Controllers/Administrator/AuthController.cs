
﻿using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;

namespace post_office.Controllers.Administrator
{
    public class AuthController : Controller
    {
        /*VIEW*/
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
           
            /*var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test send email", "vohuyhngoctramm@gmail.com"));
            message.To.Add(new MailboxAddress("hehe", "us@gmail.com"));
            message.Subject = "test mail in asp.net core";
            message.Body = new TextPart("plain")
            {
                Text = "hello this is the first time im try send mail in aspnet core"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("vohuyhngoctramm@gmail.com", "0907283275");
                client.Send(message);
                client.Disconnect(true);
            }*/
            return View();
        }

        //role
        public IActionResult Roles()
        {
            return RedirectToAction("Index","Role");
        }

        //users
        public IActionResult Users()
        {
           
            return RedirectToAction("Index", "User");

        }

        //branches
        public IActionResult Branches()
        {
            return RedirectToAction("Index", "Branch");

        }

        //services

        public IActionResult Service()
        {
            return RedirectToAction("Index","Services");

        }

        //product cate

        public IActionResult ProductCategory()
        {
            return RedirectToAction("Index", "ProductCategory");

        }
        //product 

        public IActionResult Products()
        {
            return RedirectToAction("Index", "Products");

        }
        //attributes

        public IActionResult Attributes()
        {
            return RedirectToAction("Index","Attribute");
        }

        /*END VIEW*/

    }
}
