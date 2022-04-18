
﻿using Microsoft.AspNetCore.Mvc;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class BranchController : Controller
    {
        public static int id = 0;
        IBranchService _Branchsvc = null;
        public BranchController(IBranchService BranchService)
        {
            _Branchsvc = BranchService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
