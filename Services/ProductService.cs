using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IProductService
    {
        ProductModel SaveProduct(ProductModel mdl);
    }
    public class ProductService : IProductService
    {
        public ProductModel SaveProduct(ProductModel mdl)
        {
            return null;
        }
    }
}
