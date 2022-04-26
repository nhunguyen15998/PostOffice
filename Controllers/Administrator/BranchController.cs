
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using post_office.Entities;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class BranchController : Controller
    {
        public static int _id = 0;
        public static string mess = "";
        IBranchService _Branchsvc = null;
        IAddressServices _addressSvc = null;
        public static List<BranchModel> ls = new List<BranchModel>();
        public BranchController(IBranchService BranchService, IAddressServices address)
        {
            _addressSvc = address;
            _Branchsvc = BranchService;
        }
        public IActionResult Index()
        {
            ViewBag.data = ls = _Branchsvc.GetListBranch().OrderByDescending(x => x.id).ToList();
            ViewBag.branchsvc = _Branchsvc;
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
        //PhoneBranchExists
        public JsonResult PhoneBranchExists(BranchModel model)
        {
            var obj = ls.FirstOrDefault(x => x.phone.ToLower() == model.phone.ToLower());
            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);

        }
        //CodeBranchExists
        public JsonResult CodeBranchExists(BranchModel model)
        {
            var obj = ls.FirstOrDefault(x => x.code.ToLower() == model.code.ToLower());
            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);

        }
        public IActionResult BranchCU(BranchModel mdl)
        {
                if (_id != 0)
                {
                    mdl.id = _id;
                    _Branchsvc.ModifyBranch(mdl);
                    _id = 0;
                }
                else _Branchsvc.SaveBranch(mdl);
                mess = "Saved successfully!";
        
            return RedirectToAction("Index");
        }
        public BranchModel GetBranch(int id)
        {
            var e= ls.FirstOrDefault(x => x.id == id);
            _id = e.id;
            return e;
        }
        public void DeleteBranches(List<int> ls)
        {
            bool delete = _Branchsvc.RemoveBranches(ls);
            mess = "Deleted successfully!";
            if (!delete)
                mess = (ls.Count == 1 ? "Item" : "There are some items that") + " cannot be deleted. Please make sure the item you delete is not a branch of another user";

        }
    }
}
