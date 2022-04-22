using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class ProductCategoryController : Controller
    {
        public static int _id = 0;
        public static string mess = string.Empty;
        public static int page = 1;


        IProductCategoryService _ProductCategorysvc = null;
        public static List<ProductCategoryModel> ls = new List<ProductCategoryModel>();
        public ProductCategoryController(IProductCategoryService productCategory)
        {
            _ProductCategorysvc = productCategory;
        }
        public IActionResult Index()
        {
            ViewBag.ls_parent = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "All" }, new SelectListItem { Value = "-1", Text = "Not have parent" } }.Concat( new SelectList(_ProductCategorysvc.GetListParent(), "id", "name"));
            ViewBag.lsPDCate = ls = LoadDataPDCategories(page, 0, string.Empty,-1);
            ViewBag.pagi = RowEvent(_ProductCategorysvc.GetListProductCategory().Count);

            ViewBag.lsSTS = ProductCategoryModel.ls_status;
            ViewBag.svc = _ProductCategorysvc;
            return View();
        }
        public void PDCateCU(string m)
        {
            ProductCategoryModel mdl = JsonConvert.DeserializeObject<ProductCategoryModel>(m);

            if (ModelState.IsValid)
            {
                if (_id != 0)
                {
                    mdl.id = _id;
                    _ProductCategorysvc.ModifyPDCategory(mdl);
                    _id = 0;

                }
                else _ProductCategorysvc.SavePDCategory(mdl);
                mess = "Saved successfully!";
            }

            ModelState.Clear();
        }
        public void DeletePDCategory(List<int> ls)
        {
            bool delete = _ProductCategorysvc.RemovePDCategory(ls);
            mess = "Deleted successfully!";
            if (!delete)
                mess = (ls.Count == 1 ? "Item" : "There are some items that") + " cannot be deleted. Please make sure the item you delete is not a parent of another item / with the own product";
            
        }
        public JsonResult NamePDCateExists(string name, int parent)
        {
            var obj = ls.FirstOrDefault(x => x.name.ToLower() == name.ToLower() && (parent == 0 ? true : parent == x.parent_id));

            if (_id != 0 && obj != null) { obj = obj.id != _id ? obj : null; }
            return Json(obj == null ? true : false);
        }
        public string GetParentName(int parentID)
        {
            return parentID == 0 ? "" : _ProductCategorysvc.GetProductCategory(parentID).name;
        }
        public ProductCategoryModel GetPDCategory(int id)
        {
            var w = _ProductCategorysvc.GetProductCategory(id);
            _id = w.id;

            return w;
        }
        public string GetParentOption(int id)
        {
            var w = id == 0 ? _ProductCategorysvc.GetListProductCategory().Where(x=>x.status==1) : _ProductCategorysvc.GetListProductCategory().Where(x => x.id != id&&x.parent_id!=id&&x.status==1);
           
            string res = "<option value='0'>None</option>";
            var ele = id != 0?_ProductCategorysvc.GetProductCategory(id).parent_id:0;
            if (id != 0)
            {
                var obj = _ProductCategorysvc.GetProductCategory(ele??0);
                if (obj!=null?obj.status == 0:false)
                {
                    res += "<option selected='selected' value=" +obj.id + ">" +obj.name + "</option>";
                }
            }
            foreach (var item in w)
            {
                if (ele== item.id)
                    res += "<option selected='selected' value=" + item.id+">"+item.name+"</option>";
               else res += "<option value=" + item.id + ">" + item.name + "</option>";

            }
            return res;
        }
        //Pagination
        public List<ProductCategoryModel> LoadDataPDCategories(int p, int parent, string name, int status)
        {
            int currentSkip = 10 * (p - 1);
            var w= _ProductCategorysvc.GetListProductCategory().Where(x => x.name.ToLower().Contains(name == null ? "" : name.ToLower())
                                                                            &&(status==-1?true:x.status == status)
                                                                            &&( parent == -1 ? x.parent_id == null : (parent == 0? true : x.parent_id == parent))).OrderByDescending(x => x.id).Skip(currentSkip).Take(10).ToList();
            return w;
          }
        public int GetCountPDCategories(int parent, string name, int status)
        {
            return _ProductCategorysvc.GetListProductCategory().Where(x => x.name.ToLower().Contains(name == null ? "" : name.ToLower())
                                                                            && (status == -1 ? true : x.status == status)
                                                                            && (parent == -1 ? x.parent_id == null : (parent == 0 ? true : x.parent_id == parent))).OrderByDescending(x => x.id).ToList().Count;


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
