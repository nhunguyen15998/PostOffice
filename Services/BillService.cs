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
        int CreateBill(List<ProductBillModel> productBill, List<ProductBillDetailModel> productBillDetails, 
                      OrderModel order, List<OrderDetailModel> orderDetails, List<OrderPhotoModel> orderPhotos, List<OrderTrackingModel> orderTracking,
                      List<BillModel> bill);
        List<ReadBillModel> GetBills(int customerId, int billId);//, int pageIndex, int pageSize);
        ReadBillModel GetBill(int customerId, int billId);
        List<OrderDetailModel> GetOrderDetails(int orderId);
        List<OrderPhotoModel> GetOrderPhotos(int orderId);
        List<OrderTrackingModel> GetOrderTrackings(int orderId);
        ProductBillModel GetProductBill(int? productBillId);
        List<ProductBillDetailModel> GetProducts(int? productBillId);
        List<OrderTrackingModel> GetOrderTrackings(string orderCode);
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
                        ProductBillId = productBillId, ProductId = item.ProductId, Code = item.Code, 
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

        public List<ReadBillModel> GetBills(int customerId, int billId)//, int pageIndex, int pageSize)
        {
            try {
                return _context.Bills.Join(_context.Orders, x => x.OrderId, y => y.Id, (x, y) => new ReadBillModel{
                                        Id = x.Id,
                                        Code = y.Code,
                                        Total = x.Total,
                                        SenderId = y.SenderId,
                                        SenderFirstName = y.SenderFirstName,
                                        SenderLastName = y.SenderLastName,
                                        SenderPhone = y.SenderPhone,
                                        SenderEmail = y.SenderEmail, 
                                        CompanyName = y.CompanyName,
                                        CompanyPhone = y.CompanyPhone,
                                        FromAddress = y.FromAddress,
                                        FromWard = y.FromWard.Name,
                                        FromCity = y.FromCity.Name,
                                        FromProvince = y.FromProvince.Name, 
                                        ReceiverFirstName = y.ReceiverFirstName,
                                        ReceiverLastName = y.ReceiverLastName,
                                        ReceiverPhone = y.ReceiverPhone,
                                        ReceiverEmail = y.ReceiverEmail, 
                                        ToAddress = y.ToAddress,
                                        ToWard = y.ToWard.Name,
                                        ToCity = y.ToCity.Name,
                                        ToProvince = y.ToProvince.Name, 
                                        CreatedAt = x.CreatedAt,
                                        Status = x.Status,
                                        Length = y.Length,
                                        Height = y.Height,
                                        Width = y.Width,
                                        Weight = y.Weight,
                                        DeliveryOn = y.DeliveryOn,
                                        PaidOn = x.PaidOn,
                                        PinCode = y.PinCode,
                                        ServiceName = x.ServiceName,     
                                        PickUpFee  = x.PickUpFee,
                                        IsPickup = x.IsPickup,
                                        SendingOn = x.SendingOn,
                                        DeliveryStatus = y.DeliveryStatus,
                                        DeliveryFee = y.DeliveryFee,
                                        CollectAmount = y.CollectAmount,
                                        Notes = y.Notes, 
                                        PaymentType = x.PaymentType,
                                        PaymentStatus = x.PaymentStatus,
                                        OrderId = y.Id,
                                        ProductBillId = x.ProductBillId
                                    })
                                    .Where(x => x.SenderId == customerId) 
                                    .Where(x => billId != 0 ? x.Id == billId : true) 
                                    //.Skip((pageIndex - 1) * pageSize)
                                    //.Take(pageSize)
                                    .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public ReadBillModel GetBill(int customerId, int billId)
        {
            try {
                return GetBills(customerId, billId).FirstOrDefault();                      
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public List<OrderDetailModel> GetOrderDetails(int orderId)
        {
            try {
                return _context.Orders.Where(x => x.Id == orderId)
                                      .Join(_context.OrderDetails, x => x.Id, y => y.OrderId, 
                                            (x, y) => new OrderDetailModel{
                                                OrderId = x.Id,
                                                Name = y.Name,
                                                Qty = y.Qty,
                                                CreatedAt = y.CreatedAt 
                                            })
                                       .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public List<OrderPhotoModel> GetOrderPhotos(int orderId)
        {
            try {
                return _context.Orders.Where(x => x.Id == orderId)
                                       .Join(_context.OrderPhotos, x => x.Id, y => y.OrderId, 
                                            (x, y) => new OrderPhotoModel{
                                                OrderId = x.Id,
                                                Photo = y.Photo,
                                                CreatedAt = y.CreatedAt 
                                            })
                                       .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public List<OrderTrackingModel> GetOrderTrackings(int orderId)
        {
            try {
                return _context.Orders.Where(x => x.Id == orderId)
                                      .Join(_context.OrderTrackings, x => x.Id, y => y.OrderId, 
                                            (x, y) => new OrderTrackingModel{
                                                OrderId = x.Id,
                                                Code = y.Code,
                                                Shipper = y.Shipper.FullName,
                                                Description = y.Description,
                                                Branch = y.Branch.Name,
                                                CreatedAt = y.CreatedAt 
                                            })
                                       .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        //product
        public ProductBillModel GetProductBill(int? productBillId)
        {
            try {
                if(productBillId == null) return null;
                return _context.ProductBills.Where(x => x.Id == productBillId)
                                            .Select(y => new ProductBillModel{
                                               Id = productBillId,
                                               CustomerId = y.CustomerId,
                                               Total = y.Total,
                                               Status = y.Status,
                                               PaymentStatus = y.PaymentStatus,
                                               CreatedAt = y.CreatedAt
                                            })
                                            .FirstOrDefault();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public List<ProductBillDetailModel> GetProducts(int? productBillId)
        {
            try {
                if(productBillId == null) return null;
                return _context.ProductBills.Where(x => x.Id == productBillId)
                                            .Join(_context.ProductBillDetails, y => y.Id, x => x.ProductBillId, 
                                                    (y, x) => new ProductBillDetailModel{
                                                        ProductBillId = x.Id,
                                                        ProductId = x.ProductId,
                                                        Photo = x.Product.Thumbnail,
                                                        Name = x.Name,
                                                        Code = x.Code,
                                                        Color = x.Color,
                                                        Length = x.Length,
                                                        Width = x.Width,
                                                        Height = x.Height,
                                                        Price = x.Price,
                                                        Qty = x.Qty,
                                                        SubTotal = x.SubTotal,
                                                        CreatedAt = x.CreatedAt
                                                    })
                                            .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }


        //tracking
        public  List<OrderTrackingModel> GetOrderTrackings(string orderCode)
        {
            try {
                return _context.Orders.Where(x => x.Code == orderCode)
                                      .Join(_context.OrderTrackings, x => x.Id, y => y.OrderId,
                                            (x,y) => new OrderTrackingModel{
                                                Description = y.Description,
                                                OrderId = x.Id,
                                                Code = y.Code,
                                                Shipper = y.Shipper.FullName,
                                                Branch = y.Branch.Name + " - " + y.Branch.City.Name + ", " + y.Branch.Province.Name,
                                                CreatedAt = y.CreatedAt
                                            })
                                      .OrderByDescending(x => x.CreatedAt)
                                      .ToList();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

    }
}
