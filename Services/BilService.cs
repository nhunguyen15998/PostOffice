using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Entities;
using Microsoft.EntityFrameworkCore;

namespace post_office.Services
{
    public interface IBillService
    {
        //client
            //create bill 
            //       order + orderdetail + orderphoto + ordertracking
            //       productbill + productbilldetail
            //      -> billorder
        int CreateBill(ProductBillModel productBill, List<ProductBillDetailModel> productBillDetails, 
                      List<OrderModel> orders, List<OrderDetailModel> orderDetails, List<OrderPhotoModel> orderPhotos, OrderTrackingModel orderTracking,
                      BillModel bill);
        
    }

    public class BillService : IBillService
    {
        private DataContext _context;

        public BillService(DataContext context)
        {
            _context = context;
        }

        public int CreateBill(ProductBillModel productBill, List<ProductBillDetailModel> productBillDetails, 
                      List<OrderModel> orders, List<OrderDetailModel> orderDetails, List<OrderPhotoModel> orderPhotos, OrderTrackingModel orderTracking,
                      BillModel bill)
        {
            var transaction = _context.Database.BeginTransaction();
            try {
                //order
                var _orderItem = new Order();
                _context.Entry<Order>(_orderItem).CurrentValues.SetValues(orders); 
                _context.Entry<Order>(_orderItem).State = EntityState.Added;
                _context.SaveChanges();

                var _orderDetailItem = new OrderDetail();
                _context.Entry<OrderDetail>(_orderDetailItem).CurrentValues.SetValues(orderDetails); 
                _context.Entry<OrderDetail>(_orderDetailItem).State = EntityState.Added;
                _context.SaveChanges();

                var _orderPhoto = new OrderPhoto();
                _context.Entry<OrderPhoto>(_orderPhoto).CurrentValues.SetValues(orderPhotos); 
                _context.Entry<OrderPhoto>(_orderPhoto).State = EntityState.Added;
                _context.SaveChanges();

                var _orderTracking = new OrderTracking();
                _context.Entry<OrderTracking>(_orderTracking).CurrentValues.SetValues(orderTracking); 
                _context.Entry<OrderTracking>(_orderTracking).State = EntityState.Added;
                _context.SaveChanges();

                //product
                var _productBill = new ProductBill();
                _context.Entry<ProductBill>(_productBill).CurrentValues.SetValues(productBill); 
                _context.Entry<ProductBill>(_productBill).State = EntityState.Added;
                _context.SaveChanges();

                var _productBillDetail = new ProductBillDetail();
                _context.Entry<ProductBillDetail>(_productBillDetail).CurrentValues.SetValues(productBillDetails); 
                _context.Entry<ProductBillDetail>(_productBillDetail).State = EntityState.Added;
                _context.SaveChanges();

                //bill
                var _bill = new Bill();
                _context.Entry<Bill>(_bill).CurrentValues.SetValues(bill); 
                _context.Entry<Bill>(_bill).State = EntityState.Added;
                _context.SaveChanges();

                transaction.Commit();
                return 1;
            } catch(Exception ex) {
                transaction.Rollback();
                var a = ex.Message;
                throw;
            }
        }

    }
}