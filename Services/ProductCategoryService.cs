using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IProductCategoryService
    {
        bool ModifyPDCategory(ProductCategoryModel mdl);
        ProductCategoryModel SavePDCategory(ProductCategoryModel mdl);
        ProductCategoryModel GetProductCategory(int id);
        List<ProductCategoryModel> GetListProductCategory();
        List<ProductCategoryModel> GetListParent();
        bool RemovePDCategory(List<int> ls);
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private DataContext _context;

        public ProductCategoryService(DataContext context)
        {
            _context = context;
        }
        public ProductCategoryModel SavePDCategory(ProductCategoryModel mdl)
        {
            var c = new ProductCategory() { Name = mdl.name, ParentId = mdl.parent_id==0?null:mdl.parent_id, CreatedAt = DateTime.Now, Status = mdl.status };
            _context.ProductCategories.Add(c);
            _context.SaveChanges();
            mdl.id = c.Id;
            return mdl;
        }
        public bool ModifyPDCategory(ProductCategoryModel mdl)
        {
            bool check = true;
            var pdc = _context.ProductCategories.FirstOrDefault(x=>x.Id == mdl.id);
            if (pdc != null)
            {
                pdc.ParentId = mdl.parent_id == 0 ? null : mdl.parent_id;
                pdc.Name = mdl.name;
                pdc.Status = mdl.status;
                _context.SaveChanges();
               
            }
            return check ;
        }

        public ProductCategoryModel GetProductCategory(int id)
        {
            return _context.ProductCategories.Select(x => new ProductCategoryModel() { id = x.Id, name = x.Name, parent_id = x.ParentId,status = x.Status, createdAt = (DateTime)x.CreatedAt }).FirstOrDefault(x => x.id == id)??null; 
        }
        public List<ProductCategoryModel> GetListProductCategory()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryModel() { id = x.Id, name = x.Name, parent_id=x.ParentId,status = x.Status, createdAt = (DateTime)x.CreatedAt }).ToList() ?? null;
        }
        public List<ProductCategoryModel> GetListParent() {
            var w= _context.ProductCategories.Select(x => new ProductCategoryModel() { id = x.Id, name = x.Name, parent_id = x.ParentId, status = x.Status, createdAt = (DateTime)x.CreatedAt }).Where(x => x.parent_id != null).ToList();
            List<int> ls = new List<int>();
            foreach (var item in w)
            {
                if (!ls.Contains((int)item.parent_id))
                    ls.Add((int)item.parent_id);
            }
            var res = new List<ProductCategoryModel>();
            foreach (var item in ls)
            {
                res.Add(GetProductCategory(item));
            }
            return res;
        }
        //Product category is the Parent of another item, product that is not deleted
        public bool RemovePDCategory(List<int> ls)
        {
            bool check = true;
            foreach (var item in ls)
            {
                var r = _context.ProductCategories.FirstOrDefault(x => x.Id == item);
                if (r != null)
                {
                    var parent = _context.ProductCategories.FirstOrDefault(x => x.ParentId == r.Id);
                    var product = _context.Products.FirstOrDefault(x => x.CategoryId == r.Id);
                    if (parent == null && product == null)
                    {
                        _context.ProductCategories.Remove(r);
                        _context.SaveChanges();
                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            return check;
        }



    }
}
