using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IProductService
    {
        DataContext GetDataContext();
        ProductModel SaveProduct(ProductModel mdl);
        List<ProductModel> GetListProduct();
        List<ProductAttributeModel> GetListProductAttribute();
        ProductAttributeModel SaveProductAttribute(ProductAttributeModel m);
        int GetTotalQuantity(int pid);
        string GetPrice(int pid);
    }
    public class ProductService : IProductService
    {

        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public DataContext GetDataContext()
        {
            return _context;
        }
        public ProductModel SaveProduct(ProductModel mdl)
        {
            _context.Products.Add(new Product() { CategoryId = mdl.categoryId, Code = mdl.code, Description = mdl.description, Price = mdl.price, Qty = mdl.qty, Thumbnail = mdl.thumbnail, Name = mdl.name, Status = mdl.status, CreatedAt = DateTime.Now });
            _context.SaveChanges();
            return mdl;
        }
        public ProductAttributeModel SaveProductAttribute(ProductAttributeModel m)
        {
            _context.ProductAttributes.Add(new ProductAttribute() { ColorId = m.colorID, HeightId = m.heightID, LengthId = m.lengthID, WidthId = m.widthID, CreatedAt = DateTime.Now, Price = m.price, Qty = m.qty, ProductId = m.productId });
            _context.SaveChanges();
            return m;
        }
        public List<ProductModel> GetListProduct()
        {
            return _context.Products.Select(x => new ProductModel() { id = x.Id, name = x.Name, code = x.Code, categoryId= x.CategoryId,description=x.Description, price=x.Price, qty=x.Qty, thumbnail=x.Thumbnail, status=x.Status, createdAt = (DateTime)x.CreatedAt }).ToList();

        }
        public List<ProductAttributeModel> GetListProductAttribute()
        {
            return _context.ProductAttributes.Select(x => new ProductAttributeModel() { id = x.Id, colorID = x.ColorId, heightID = x.HeightId, lengthID = x.LengthId, widthID = x.WidthId,price = x.Price, createAt=(DateTime) x.CreatedAt,productId=x.ProductId, qty=(int)x.Qty }).ToList();

        }
        public int GetTotalQuantity(int pid)
        {
            var pd = GetListProduct().FirstOrDefault(x => x.id == pid).qty ?? 0;
            var ls_PDattr = GetListProductAttribute().Where(x => x.productId == pid).ToList();
            var res = 0;
            foreach (var item in ls_PDattr)
            {
                res += item.qty;
            }
            return res + pd;
        }
        public string GetPrice(int pid)
        {
            var pd = GetListProduct().FirstOrDefault(x => x.id == pid).price ?? 0;
            var ls_PDattr = GetListProductAttribute().Where(x => x.productId == pid).Select(x=>x.price).ToList();
            ls_PDattr.Add(pd);
            string res =string.Format("0:n0", ls_PDattr[0]);
            if (ls_PDattr.Count >= 2) res = string.Format("0:n0", ls_PDattr.Min())+" - "+ string.Format("0:n0", ls_PDattr.Max());
            return res;
        }



    }
}
