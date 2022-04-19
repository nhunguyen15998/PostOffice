using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace post_office.Entities
{
    public class DataContext : DbContext
    {
        public static string _dbConnection;

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }
        //Attribute
        public DbSet<Attribute> Attributes { get; set; }
        //Bill
        public DbSet<Bill> Bills { get; set; }
        //BillOrder
        public DbSet<BillOrder> BillOrders { get; set; }
        //Blog
        public DbSet<Blog> Blogs { get; set; }
        //Branch
        public DbSet<Branch> Branches { get; set; }
        //Contact
        public DbSet<Contact> Contacts { get; set; }
        //Customer
        public DbSet<Customer> Customers { get; set; }
        //CustomerAddress
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        //Order 
        public DbSet<Order> Orders { get; set; }
        //OrderDetail 
        public DbSet<OrderDetail> OrderDetails { get; set; }   
        //OrderDetailPhoto
        public DbSet<OrderPhoto> OrderPhotos { get; set; }
        
        //OrderTracking
        public DbSet<OrderTracking> OrderTrackings { get; set; }
        //Permissions
        public DbSet<Permission> Permissions { get; set; }
        //PinCode
        public DbSet<PinCode> PinCodes { get; set; }

        //Product
        public DbSet<Product> Products { get; set; }
        //ProductAttribute
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        //ProductBill
        public DbSet<ProductBill> ProductBills { get; set; }
        //ProductBillDetail
        public DbSet<ProductBillDetail> ProductBillDetails { get; set; }
        //ProductCategory
        public DbSet<ProductCategory> ProductCategories { get; set; }
        //ProductPhoto  
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        //Role
        public DbSet<Role> Roles { get; set; }
        //RolePermission
        public DbSet<RolePermission> RolePermissions { get; set; }
        //Service
        public DbSet<Service> Services { get; set; }  
        //User
        public DbSet<User> Users { get; set; }      

        //ward - city - province - country ###COMMENT WHEN RUN MIGRATION
        public DbSet<Ward> Wards { get; set; }  
        public DbSet<City> Cities { get; set; }  
        public DbSet<State> States { get; set; }  
        public DbSet<Country> Countries { get; set; }  
    }
}