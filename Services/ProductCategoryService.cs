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
    }
    public class ProductCategoryService : IProductCategoryService
    {
        public ProductCategoryModel SaveProductCategory(ProductCategoryModel mdl)
        {
            return null;
        }
    }
}
