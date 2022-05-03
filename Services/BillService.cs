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
        int CreateBill(List<ProductBillModel> productBill, List<ProductBillDetailModel> productBillDetails, 
                      OrderModel order, List<OrderDetailModel> orderDetails, List<OrderPhotoModel> orderPhotos, List<OrderTrackingModel> orderTracking,
                      List<BillModel> bill);
        
    }

    public class BillService : IBillService
    {
        private DataContext _context;

        public BillService(DataContext context)
        {
            _context = context;
        }

        public int CreateBill(List<ProductBillModel> productBill, List<ProductBillDetailModel> productBillDetails, 
                            OrderModel order, List<OrderDetailModel> orderDetails, List<OrderPhotoModel> orderPhotos, List<OrderTrackingModel> orderTracking,
                            List<BillModel> bill)
        {
            var transaction = _context.Database.BeginTransaction();
            try {
                //order
                var _orderItem = new Order();
                _context.Entry<Order>(_orderItem).CurrentValues.SetValues(order); 
                _context.Entry<Order>(_orderItem).State = EntityState.Added;
                _context.SaveChanges();
                var orderId = _orderItem.Id;

                //orderdetail
                List<OrderDetail> _orderDetails = new List<OrderDetail>();
                foreach(var item in orderDetails){
                    _orderDetails.Add(new OrderDetail{ OrderId = orderId, Name = item.Name, Qty = item.Qty, CreatedAt = DateTime.Now });
                }
                _context.OrderDetails.AddRange(_orderDetails);
                _context.SaveChanges();

                //orderphoto
                List<OrderPhoto> _orderPhotos = new List<OrderPhoto>();
                foreach(var item in orderPhotos){
                    _orderPhotos.Add(new OrderPhoto{ OrderId = orderId, Photo = item.Photo, CreatedAt = DateTime.Now });
                }
                _context.OrderPhotos.AddRange(_orderPhotos);
                _context.SaveChanges();

                //ordertracking
                List<OrderTracking> _orderTrackings = new List<OrderTracking>();
                foreach(var item in orderTracking){
                    _orderTrackings.Add(new OrderTracking{ OrderId = orderId, Code = item.Code, Description = item.Description, BranchId = item.BranchId, CreatedAt = DateTime.Now });
                }
                _context.OrderTrackings.AddRange(_orderTrackings);
                _context.SaveChanges();

                //product
                ProductBill _productBill = new ProductBill();
                foreach(var item in productBill){
                    _productBill.CustomerId = item.CustomerId;
                    _productBill.Status = item.Status;
                    _productBill.Total = item.Total;
                    _productBill.PaymentStatus = item.PaymentStatus;
                    _productBill.CreatedAt = DateTime.Now;
                    break;
                }
                _context.ProductBills.Add(_productBill);
                _context.SaveChanges();
                var productBillId = _productBill.Id;

                //productdetail
                List<ProductBillDetail> _productBillDetails = new List<ProductBillDetail>();
                foreach(var item in productBillDetails){
                    _productBillDetails.Add(new ProductBillDetail{ 
                        ProductBillId = productBillId, ProductAttributeId = item.ProductAttributeId, Code = item.Code, 
                        Name = item.Name, Color = item.Color, Length = item.Length, Width = item.Width, Height = item.Height,
                        Qty = item.Qty, Price = item.Price, SubTotal = item.SubTotal, CreatedAt = DateTime.Now });
                }
                _context.ProductBillDetails.AddRange(_productBillDetails);
                _context.SaveChanges();

                //bill
                Bill _bill = new Bill();
                foreach(var item in bill){
                    _bill.OrderId = orderId;
                    _bill.ProductBillId = productBillId;
                    _bill.ServiceId = item.ServiceId;
                    _bill.ServiceName = item.ServiceName;
                    _bill.Code = item.Code;
                    _bill.IsPickup = item.IsPickup;
                    _bill.PickUpFee = item.PickUpFee;
                    _bill.Total = item.Total;
                    _bill.PaymentType = item.PaymentType;
                    _bill.PaidOn = DateTime.Now;
                    _bill.BranchId = item.BranchId;
                    _bill.PaymentStatus = item.PaymentStatus;
                    _bill.CreatedAt = DateTime.Now;
                    break;
                }
                _context.Bills.Add(_bill);
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
