
﻿using post_office.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Services;
using MimeKit;
using MailKit.Net.Smtp;

namespace post_office.Controllers.Administrator
{
    public class AuthController : Controller
    {
        /*VIEW*/
       
   

        public IActionResult Dashboard()
        {

          
            if (AuthenticetionModel.id != 0)
                return View();
            return RedirectToAction("Index","User");
        }

        //role
        public IActionResult Roles()
        {
                return RedirectToAction("Index", "Role");
            
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
                return RedirectToAction("Index", "Services");

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
                return RedirectToAction("Index", "Attribute");
        }
        //Bills

        public IActionResult Bills()
        {
                return RedirectToAction("Index", "Bills");
        }
        //Customers
        public IActionResult Customers()
        {
                return RedirectToAction("Index", "Customers");
        }
        //SettingFee
        public IActionResult SettingFee()
        {
                return RedirectToAction("Index", "SettingFee");
        }
        /*END VIEW*/

    }
}
