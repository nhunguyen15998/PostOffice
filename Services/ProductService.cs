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
        List<ProductModel> GetListProduct(int categoryId, int status);
        List<ProductAttributeModel> GetListProductAttribute();
        ProductAttributeModel SaveProductAttribute(ProductAttributeModel m);
        int GetTotalQuantity(int pid);
        string GetPrice(int pid);
        ProductModel GetProduct(int id);
    }
    public class ProductService : IProductService
    {

        private  DataContext ct;

        public ProductService(DataContext context)
        {
            ct = context;
        }
        public DataContext GetDataContext()
        {
            return ct;
        }
        public ProductModel SaveProduct(ProductModel mdl)
        {
            var m= new Product() { CategoryId = mdl.categoryId, Code = mdl.code, Description = mdl.description, Price = mdl.price, Qty = mdl.qty, Thumbnail = mdl.thumbnail, Name = mdl.name, Status = mdl.status, CreatedAt = DateTime.Now };
            ct.Products.Add(m);
            ct.SaveChanges();
            mdl.id = m.Id;
            return mdl;
        }
        public ProductAttributeModel SaveProductAttribute(ProductAttributeModel m)
        {
            ct.ProductAttributes.Add(new ProductAttribute() { ColorId = m.colorID, HeightId = m.heightID, LengthId = m.lengthID, WidthId = m.widthID, CreatedAt = DateTime.Now, Price = m.price, Qty = m.qty, ProductId = m.productId });
            ct.SaveChanges();
            return m;
        }
        public List<ProductModel> GetListProduct(int categoryId, int status)
        {
            var a = ct.Products.Where(x => categoryId != 0 ? x.CategoryId == categoryId : true)
                              .Where(x => status == 1 ? x.Status == status : true)
                              .Select(x => new ProductModel() { id = x.Id, name = x.Name, code = x.Code, categoryId= x.CategoryId,description=x.Description, price=x.Price, qty=x.Qty, thumbnail=x.Thumbnail, status=x.Status, createdAt = (DateTime)x.CreatedAt }).ToList();
            return a;
        }
        public List<ProductAttributeModel> GetListProductAttribute()
        {
            return ct.ProductAttributes.Select(x => new ProductAttributeModel() { id = x.Id, colorID = x.ColorId, heightID = x.HeightId, lengthID = x.LengthId, widthID = x.WidthId,price = x.Price, createAt=(DateTime) x.CreatedAt,productId=x.ProductId, qty=(int)x.Qty }).ToList();

        }
        public ProductModel GetProduct(int id)
        {
            return ct.Products.Select(x => new ProductModel() { id = x.Id, name = x.Name, code = x.Code, categoryId = x.CategoryId, description = x.Description, price = x.Price, qty = x.Qty, thumbnail = x.Thumbnail, status = x.Status, createdAt = (DateTime)x.CreatedAt }).FirstOrDefault(x => x.id == id) ?? null;
        }
        public int GetTotalQuantity(int pid)
        {
            var pd = GetListProduct(0,0).FirstOrDefault(x => x.id == pid).qty ?? 0;
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
            var pd = GetListProduct(0,0).FirstOrDefault(x => x.id == pid).price ?? 0;
            var ls_PDattr = GetListProductAttribute().Where(x => x.productId == pid).Select(x=>x.price).ToList();
            ls_PDattr.Add(pd);
            string res =string.Format("{0:n0}", ls_PDattr[0]);
            if (ls_PDattr.Count >= 2) res = string.Format("{0:n0}", ls_PDattr.Min())+" - "+ string.Format("{0:n0}", ls_PDattr.Max());
            return res;
        }



    }
}
