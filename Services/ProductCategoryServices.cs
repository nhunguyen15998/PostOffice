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
        ProductCategoryModel SaveProductCategory(ProductCategoryModel mdl);
        ProductCategoryModel GetProductCategory(int id);
        List<ProductCategoryModel> GetListProductCategory();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private DataContext _context;

        public ProductCategoryService(DataContext context)
        {
            _context = context;
        }
        public ProductCategoryModel SaveProductCategory(ProductCategoryModel mdl)
        {
            var c = new ProductCategory() { Name = mdl.name, ParentId = mdl.parent_id, CreatedAt = DateTime.Now, Status = mdl.status };
            _context.ProductCategories.Add(c);
            _context.SaveChanges();
            mdl.id = c.Id;
            return mdl;
        }
        public  ProductCategoryModel GetProductCategory(int id)
        {
            return _context.ProductCategories.Select(x => new ProductCategoryModel() { id = x.Id, name = x.Name, status = x.Status, createdAt = (DateTime)x.CreatedAt }).FirstOrDefault(x => x.id == id)??null; 
        }
        public List<ProductCategoryModel> GetListProductCategory()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryModel() { id = x.Id, name = x.Name, status = x.Status, createdAt = (DateTime)x.CreatedAt }).ToList() ?? null;
        }

    }
}
