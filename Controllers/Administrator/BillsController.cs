using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class BillsController : Controller
    {
        private readonly ILogger<BillsController> _logger;
        private IBillService _billService;
        private ILocationService _locationService;
        private IServiceService _serviceService;
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        private ICustomerService _customerService;
        private IBranchService _branchService;
        public BillsController(ILogger<BillsController> logger, 
        IBillService billService, ILocationService locationService, IProductService productService,
        IServiceService serviceService, IProductCategoryService productCategoryService, ICustomerService customerService,
        IBranchService branchService)
        {
            _logger = logger;
            _billService = billService;
            _locationService = locationService;
            _serviceService = serviceService;
            _productCategoryService = productCategoryService;
            _productService =  productService;
            _customerService = customerService;
            _branchService= branchService;
        }

        public IActionResult Index()
        {
            if (AuthenticetionModel.id != 0)
            {
                ViewBag.Bills = GetBills();
                return View();
            }
            else return RedirectToAction("Login", "User");
        }

        public List<ReadBillModel> GetBills()
        {
            try {
                return _billService.GetBills(0, 0);//, pageIndex ?? 1, pageSize);
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public IActionResult BillDetailCreate()
        {
            if (AuthenticetionModel.id == 0)
            {
                return RedirectToAction("Login", "User");
            }
            try {
                //location
                ViewBag.CreateFromProvinces = GetProvinces(0);
                ViewBag.CreateToProvinces = GetProvinces(0);
                //service
                ViewBag.Services = _serviceService.GetServiceById(0)
                                                  .Select(x => new SelectListItem{
                                                      Value = x.id.ToString(),
                                                      Text = x.name
                                                  })
                                                  .ToList();
                //deliverystt
                ViewBag.DeliveryStatus = Helpers.Helpers.DeliveryStatusList();

                //product cate
                ViewBag.ProductCateList = _productCategoryService.GetListProductCategory()
                                                                .Select(x => new SelectListItem{Value = x.id.ToString() ?? "0",  Text = x.name}).ToList();
                ViewBag.CustomerIds = _customerService.GetAll(1);

                ViewBag.Branches = _branchService.GetListBranch();
                return View();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        public IActionResult BillDetailUpdate(int billId)
        {
            if (AuthenticetionModel.id == 0)
            {
                return RedirectToAction("Login", "User");
            }
            try {
                var bill = _billService.GetBill(0, billId);
                ViewBag.Bill = bill;
                ViewBag.OrderDetails = _billService.GetOrderDetails(bill.OrderId);
                ViewBag.OrderPhotos = _billService.GetOrderPhotos(bill.OrderId);
                if(bill.ProductBillId != null){
                    var productBill = _billService.GetProductBill(bill.ProductBillId);
                    ViewBag.ProductBill = productBill; 
                    ViewBag.ProductBillDetails = _billService.GetProducts(productBill.Id);
                }
                //location
                ViewBag.FromProvinces = GetProvinces(bill.FromProvinceId);
                ViewBag.FromDistricts = GetDistricts(0, bill.FromCityId);
                ViewBag.FromWards = GetWards(0, bill.FromWardId);
                ViewBag.ToProvinces = GetProvinces(bill.ToProvinceId);
                ViewBag.ToDistricts = GetDistricts(0, bill.ToCityId);
                ViewBag.ToWards = GetWards(0, bill.ToWardId);
                //service
                ViewBag.Services = _serviceService.GetServiceById(0)
                                                  .Select(x => new SelectListItem{
                                                      Value = x.id.ToString(),
                                                      Text = x.name
                                                  })
                                                  .ToList();
                //deliverystt
                ViewBag.DeliveryStatus = Helpers.Helpers.DeliveryStatusList();

                //product cate
                ViewBag.ProductCateList = _productCategoryService.GetListProductCategory()
                                                                .Select(x => new SelectListItem{Value = x.id.ToString() ?? "0",  Text = x.name}).ToList();
                
                return View();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        //get products by cate
        public List<ProductModel> GetProductsByCate(int cateId)
        {
            return _productService.GetListProduct(cateId, (int)Helpers.Helpers.DefaultStatus.Activated) ?? null;
        }
        public List<ProductAttributeModel> GetProductAttributesByProduct(int productId)
        {
            return _productService.GetListProductAttribute(productId) ?? null;
        }

        //get location
        public List<SelectListItem> GetProvinces(int province)
        {
            return _locationService.GetStates().Select(x => new SelectListItem{
                                                                    Value = x.Id.ToString() ?? "0", 
                                                                    Text = x.Name})
                                                    .ToList();
        } 
        public List<SelectListItem> GetDistricts(int provinceId, int district)
        {
            return _locationService.GetCities(provinceId).Select(x => new SelectListItem{
                                                                    Value = x.Id.ToString() ?? "0", 
                                                                    Text = x.Name})
                                                    .ToList();
        } 
        public List<SelectListItem> GetWards(int districtId, int ward)
        {
            return _locationService.GetWards(districtId).Select(x => new SelectListItem{
                                                                    Value = x.Id.ToString() ?? "0", 
                                                                    Text = x.Name})
                                                    .ToList();
        } 

        public List<SelectListItem> GetReceiverDistricts(int provinceId)
        {
            var districts = _locationService.GetCities(provinceId).Select(x => new SelectListItem{
                                                                    Value = x.Id.ToString() ?? "0", 
                                                                    Text = x.Name})
                                                    .ToList();
            ViewBag.CreateFromDistricts = districts;
            ViewBag.CreateToDistricts = districts;
            return districts;
        } 
        public List<SelectListItem> GetReceiverWards(int districtId)
        {
            var wards = _locationService.GetWards(districtId).Select(x => new SelectListItem{
                                                                    Value = x.Id.ToString() ?? "0", 
                                                                    Text = x.Name})
                                                    .ToList();
            ViewBag.CreateFromWards = wards;
            ViewBag.CreateToWards = wards;
            return wards;
        } 

        [HttpPost]
        public IActionResult Create()
        {
            try {//sen
                    var SenderFirstName = Request.Form["sender-first-name"].ToString();
                    var SenderId = int.Parse(Request.Form["sender-id"].ToString());
                    var SenderLastName = Request.Form["sender-last-name"].ToString();
                    var SenderPhone = Request.Form["sender-phone"].ToString();
                    var SenderEmail = Request.Form["sender-email"].ToString();
                    var CompanyName = Request.Form["sender-company-name"].ToString();
                    var CompanyPhone = Request.Form["sender-company-phone"].ToString();
                    var FromAddress = Request.Form["sender-address"].ToString();
                    var FromProvinceId = int.Parse(Request.Form["FromProvinceId"].ToString());
                    var FromCityId = int.Parse(Request.Form["sender-district"].ToString());
                    var FromWardId = int.Parse(Request.Form["sender-ward"].ToString());
                    //rec
                    var ReceiverFirstName = Request.Form["receiver-first-name"].ToString();
                    var ReceiverLastName = Request.Form["receiver-last-name"].ToString();
                    var ReceiverPhone = Request.Form["receiver-phone"].ToString();
                    var ReceiverEmail = Request.Form["receiver-email"].ToString();
                    var ToAddress = Request.Form["receiver-address"].ToString();
                    var ToProvinceId = int.Parse(Request.Form["ToProvinceId"].ToString());
                    var ToCityId = int.Parse(Request.Form["receiver-district"].ToString());
                    var ToWardId = int.Parse(Request.Form["receiver-ward"].ToString());
                    //detail
                    var Length = double.Parse(Request.Form["length"].ToString());
                    var Width = double.Parse(Request.Form["width"].ToString());
                    var Weight = double.Parse(Request.Form["weight"].ToString());
                    var Height = double.Parse(Request.Form["height"].ToString());
                    var PinCode = Request.Form["pin-code"].ToString();
                    var PaymentType = 1;//Request.Form["payment-method"].ToString();
                    var PaymentStatus = 0;//Request.Form[""].ToString();
                    var BranchId = int.Parse(Request.Form["branch"].ToString());
                    var ServiceId = int.Parse(Request.Form["select-service"].ToString());
                    var DeliveryStatus = int.Parse(Request.Form["select-delivery-status"].ToString());
                    var CollectAmount = decimal.Parse(Request.Form["amount"].ToString());
                    var SendingOn = DateTime.Parse(Request.Form["pickup-date"].ToString());
                    var IsPickup = Request.Form["chbox-pickup-date"].ToString() == ""? false : true;
                    var Notes = Request.Form["notes"].ToString();
                    var Total = decimal.Parse(Request.Form["total-hidden"].ToString());
                    var TotalProduct = decimal.Parse(Request.Form["product-hidden"].ToString());
                    var ShippingFee = decimal.Parse(Request.Form["shipping-hidden"].ToString());
                    var PickUpFee = decimal.Parse(Request.Form["pickup-hidden"].ToString());
                    //product
                    var productBill = new ProductBillModel{
                        CustomerId = SenderId,
                        Total = TotalProduct,
                        PaymentStatus = PaymentStatus,
                        Status = 0, 
                        CreatedAt = DateTime.Now
                    };
                    var createdProductBill = _billService.SaveProductBill(productBill);
                    var ProductQty = int.Parse(Request.Form["totalproducts"].ToString());
                    List<ProductBillDetailModel> ProductList = new List<ProductBillDetailModel>();
                    for(var i = 0; i < ProductQty; i++){
                        Console.WriteLine("kk:"+Request.Form["product-list-"+i.ToString()]);
                        dynamic main = JsonConvert.DeserializeObject<DataSet>(Request.Form["product-list-"+i.ToString()].ToString());
                        DataTable dataTable = main.Tables["productDetail"];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var productBillDetailModel = new ProductBillDetailModel{
                                ProductBillId = createdProductBill.Id,
                                ProductId = int.Parse(row["Id"].ToString()),
                                Name = row["Name"].ToString(),
                                Color = row["Color"].ToString(),
                                Length = row["Length"].ToString(),
                                Width = row["Width"].ToString(),
                                Height = row["Height"].ToString(),
                                Price = decimal.Parse(row["Price"].ToString()),
                                Qty = int.Parse(row["Qty"].ToString()),
                                SubTotal = decimal.Parse(row["Total"].ToString())
                            };
                            ProductList.Add(productBillDetailModel);
                        }
                    }
                    if(createdProductBill != null){
                        _billService.SaveProductBillDetails(ProductList);
                    }
                    
                    var orderItem = new OrderModel{
                        //sen
                        SenderEmail = SenderEmail,
                        SenderFirstName = SenderFirstName,
                        SenderLastName = SenderLastName,
                        SenderPhone = SenderPhone,
                        SenderId = SenderId,
                        FromAddress = FromAddress,
                        FromCityId = FromCityId,
                        FromProvinceId = FromProvinceId,
                        FromWardId = FromWardId,
                        //rec
                        ReceiverFirstName = ReceiverFirstName,
                        ReceiverLastName = ReceiverLastName,
                        ReceiverEmail = ReceiverEmail,
                        ReceiverPhone = ReceiverPhone,
                        ToAddress = ToAddress,
                        ToCityId = ToCityId,
                        ToProvinceId =ToProvinceId,
                        ToWardId =ToWardId,
                        //
                        Length= Length,
                        Weight = Weight,
                        Width = Width,
                        Height = Height,
                        PinCode = PinCode,
                        DeliveryStatus = DeliveryStatus,
                        DeliveryFee = ShippingFee,
                        CollectAmount =CollectAmount,
                        Notes =Notes,
                        CompanyName =CompanyName,
                        CompanyPhone = CompanyPhone,
                        Code = Helpers.Helpers.RandomCode(),
                        CreatedAt = DateTime.Now
                    };
                    var createdOrder = _billService.SaveOrder(orderItem);
                    if(createdOrder == null){
                        TempData["Error"] = "Cannot create bill";
                        return RedirectToAction("BillDetailCreate", "Bills");
                    }
                var billItem = new BillModel{
                    Code = Helpers.Helpers.RandomCode(),
                    CreatedAt = DateTime.Now,
                    OrderId = createdOrder.Id,
                    ServiceId = ServiceId,
                    SendingOn = SendingOn,
                    PickUpFee = PickUpFee,
                    IsPickup = IsPickup,
                    Total = Total,
                    PaymentStatus = PaymentStatus,
                    PaymentType = PaymentType,
                    Status = 0,
                    BranchId = BranchId
                };
                var createdBill = _billService.SaveBill(billItem);
                if(createdBill ==  null){
                    TempData["Error"] = "Cannot create bill";
                    return RedirectToAction("BillDetailCreate", "Bills");
                }
                //order detail
                var ParcelQty = int.Parse(Request.Form["totalparcels"].ToString());
                List<OrderDetailModel> ParcelList = new List<OrderDetailModel>();
                for(var k = 0; k < ParcelQty; k++){
                    Console.WriteLine("kk:"+Request.Form["parcel-list-"+k.ToString()]);
                    dynamic main = JsonConvert.DeserializeObject<DataSet>(Request.Form["parcels-list-"+k.ToString()].ToString());
                    DataTable dataTable = main.Tables["orderDetail"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                            var orderDetailModel = new OrderDetailModel{
                            OrderId = createdOrder.Id,
                            Name = row["Name"].ToString(),
                            Qty = int.Parse(row["Qty"].ToString()),
                        };
                        ParcelList.Add(orderDetailModel);
                    }
                
                    _billService.SaveOrderDetails(ParcelList);
                    var orderTrackingItem = new OrderTrackingModel{
                        Code = Helpers.Helpers.RandomCode(),
                        OrderId = createdOrder.Id,
                        Description = "Your order is pending",
                        BranchId = BranchId,
                        CreatedAt = DateTime.Now
                    };
                    var orderTracking = _billService.SaveOrderTracking(orderTrackingItem);
                    if(orderTracking == null){
                        TempData["error"] = "cannot create";
                        return RedirectToAction("Index", "Bills");
                    }
                    TempData["success"] = "successfully created";
                    return RedirectToAction("Index", "Bills");
                }
                 TempData["error"] = "cannot create";
                 return RedirectToAction("Index", "Bills");
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        [HttpPost]
        public IActionResult Update(int billId)
        {
            try {
                var orders = _billService.GetOrder(billId);
                var deliveryStatus = orders.DeliveryStatus;
                //sen

                    // var SenderFirstName = Request.Form["sender-first-name"].ToString();
                    // var SenderId = int.Parse(Request.Form["sender-id"].ToString());
                    // var SenderLastName = Request.Form["sender-last-name"].ToString();
                    // var SenderPhone = Request.Form["sender-phone"].ToString();
                    // var SenderEmail = Request.Form["sender-email"].ToString();
                    // var CompanyName = Request.Form["sender-company-name"].ToString();
                    // var CompanyPhone = Request.Form["sender-company-phone"].ToString();
                    // var FromAddress = Request.Form["sender-address"].ToString();
                    // var FromProvinceId = int.Parse(Request.Form["FromProvinceId"].ToString());
                    // var FromCityId = int.Parse(Request.Form["sender-district"].ToString());
                    // var FromWardId = int.Parse(Request.Form["sender-ward"].ToString());
                    //rec
                    // var ReceiverFirstName = Request.Form["receiver-first-name"].ToString();
                    // var ReceiverLastName = Request.Form["receiver-last-name"].ToString();
                    // var ReceiverPhone = Request.Form["receiver-phone"].ToString();
                    // var ReceiverEmail = Request.Form["receiver-email"].ToString();
                    // var ToAddress = Request.Form["receiver-address"].ToString();
                    // var ToProvinceId = int.Parse(Request.Form["ToProvinceId"].ToString());
                    // var ToCityId = int.Parse(Request.Form["receiver-district"].ToString());
                    // var ToWardId = int.Parse(Request.Form["receiver-ward"].ToString());
                    //detail
                    // var Length = double.Parse(Request.Form["length"].ToString());
                    // var Width = double.Parse(Request.Form["width"].ToString());
                    // var Weight = double.Parse(Request.Form["weight"].ToString());
                    // var Height = double.Parse(Request.Form["height"].ToString());
                    // var PinCode = Request.Form["pin-code"].ToString();
                    // var PaymentType = 1;//Request.Form["payment-method"].ToString();
                    // var PaymentStatus = 0;//Request.Form[""].ToString();
                    // var BranchId = int.Parse(Request.Form["branch"].ToString());
                    // var ServiceId = int.Parse(Request.Form["select-service"].ToString());
                    var DeliveryStatus = int.Parse(Request.Form["select-delivery-status"].ToString());
                    // var CollectAmount = decimal.Parse(Request.Form["amount"].ToString());
                    // var SendingOn = DateTime.Parse(Request.Form["pickup-date"].ToString());
                    // var IsPickup = Request.Form["chbox-pickup-date"].ToString() == ""? false : true;
                    // var Notes = Request.Form["notes"].ToString();
                    // var Total = decimal.Parse(Request.Form["total-hidden"].ToString());
                    // var TotalProduct = decimal.Parse(Request.Form["product-hidden"].ToString());
                    // var ShippingFee = decimal.Parse(Request.Form["shipping-hidden"].ToString());
                    // var PickUpFee = decimal.Parse(Request.Form["pickup-hidden"].ToString());

                //     var billItem = new BillModel{
                //     Code = Helpers.Helpers.RandomCode(),
                //     CreatedAt = DateTime.Now,
                //     OrderId = orders.Id,
                //     ServiceId = ServiceId,
                //     SendingOn = SendingOn,
                //     PickUpFee = PickUpFee,
                //     IsPickup = IsPickup,
                //     Total = Total,
                //     PaymentStatus = PaymentStatus,
                //     PaymentType = PaymentType,
                //     Status = 0,
                //     BranchId = BranchId
                // };
                    if(DeliveryStatus != 0 && DeliveryStatus == 3){
                        var order = new OrderModel{
                            DeliveryStatus = 3
                        };
                        var bill = new BillModel{
                            Status = 1
                        };
                        _billService.UpdateOrder(billId, order);
                        _billService.UpdateBill(billId, bill);
                        var orderTracking = new OrderTrackingModel{
                            OrderId = orders.Id,
                            Description = "Your order is delivery",
                            CreatedAt = DateTime.Now
                        };
                        _billService.SaveOrderTracking(orderTracking);
                    }
                    if(DeliveryStatus != 0 && DeliveryStatus == 4)
                    {
                        var order = new OrderModel{
                            DeliveryStatus = 4
                        };
                        var bill = new BillModel{
                            Status = 2
                        };
                        _billService.UpdateOrder(billId, order);
                        _billService.UpdateBill(billId, bill);
                        var orderTracking = new OrderTrackingModel{
                            OrderId = orders.Id,
                            Description = "Your order is completed",
                            CreatedAt = DateTime.Now
                        };
                        _billService.SaveOrderTracking(orderTracking);
                    // }else{
                    //     var orderItem = new OrderModel{
                    //     //sen
                    //     SenderEmail = SenderEmail,
                    //     SenderFirstName = SenderFirstName,
                    //     SenderLastName = SenderLastName,
                    //     SenderPhone = SenderPhone,
                    //     FromAddress = FromAddress,
                    //     FromCityId = FromCityId,
                    //     FromProvinceId = FromProvinceId,
                    //     FromWardId = FromWardId,
                    //     //rec
                    //     ReceiverFirstName = ReceiverFirstName,
                    //     ReceiverLastName = ReceiverLastName,
                    //     ReceiverEmail = ReceiverEmail,
                    //     ReceiverPhone = ReceiverPhone,
                    //     ToAddress = ToAddress,
                    //     ToCityId = ToCityId,
                    //     ToProvinceId =ToProvinceId,
                    //     ToWardId =ToWardId,
                    //     //
                    //     Length= Length,
                    //     Weight = Weight,
                    //     Width = Width,
                    //     Height = Height,
                    //     PinCode = PinCode,
                    //     DeliveryStatus = DeliveryStatus,
                    //     DeliveryFee = ShippingFee,
                    //     CollectAmount =CollectAmount,
                    //     Notes =Notes,
                    //     CompanyName =CompanyName,
                    //     CompanyPhone = CompanyPhone,
                    // };
                    //     _billService.UpdateOrder(billId, orderItem);
                    //     _billService.UpdateBill(billId, billItem);
                     }
                return View();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }
    }
}
