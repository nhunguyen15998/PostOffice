
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using post_office.Entities;
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
        public static string mess = "";
        IBranchService _Branchsvc = null;
        IAddressServices _addressSvc = null;
        public BranchController(IBranchService BranchService, IAddressServices address)
        {
            _addressSvc = address;
            _Branchsvc = BranchService;
        }
        public IActionResult Index()
        {
            ViewBag.provinceList= new List<SelectListItem> {  new SelectListItem { Text = "Select province", Value = "0"}}.Concat( new SelectList(_addressSvc.GetListStates(), "Id", "Name"));
            ViewBag.ls_status= new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } }; 
            return View();
        }
        public List<VNCity> GetCityByStateID(int stateID)
        {
            return _addressSvc.GetListCityByStateID(stateID);

        }
        public List<VNWard> GetWardByCityID(int cityID)
        {
            return _addressSvc.GetListWardByCityID(cityID);

        }
    }
}
