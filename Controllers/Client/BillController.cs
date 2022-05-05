using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using post_office.Models;
using post_office.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace post_office.Controllers.Client
{
    public class BillController : Controller
    {   
        private readonly ILogger<BillController> _logger;
        private IBillService _billService;

        public BillController(ILogger<BillController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpPost]
        public IActionResult CreateBill(List<IFormFile> Files){
            var _customer = 0;
            try{   
                List<string> orderCodes = new List<string>();
                List<int> orders = new List<int>();
                var form = Request.Form["Orders"].ToString();
                dynamic main = JsonConvert.DeserializeObject<DataSet>(form);
                DataTable dataTable = main.Tables["Bills"];
                var count = dataTable.Rows.Count;
                List<OrderModel> orderList = new List<OrderModel>();
                foreach (DataRow row in dataTable.Rows)
                {
                    var customerId = int.Parse(row["SenderId"].ToString());
                    _customer = customerId;
                    //orderdetail
                    List<OrderDetailModel> orderDetailList = new List<OrderDetailModel>();
                    dynamic orderDetail = JsonConvert.DeserializeObject<DataSet>(row["OrderDetailList"].ToString());
                    DataTable dtOrderDetail = orderDetail.Tables["OrderDetails"];
                    foreach(DataRow rOrderDetail in dtOrderDetail.Rows){
                        var item = new OrderDetailModel{
                            Name = rOrderDetail["Name"].ToString(),
                            Qty = int.Parse(rOrderDetail["Qty"].ToString()),
                        };
                        orderDetailList.Add(item);
                    }
                    //orderphoto
                    List<OrderPhotoModel> orderPhotoList = new List<OrderPhotoModel>();
                    dynamic orderPhoto = JsonConvert.DeserializeObject<DataSet>(row["OrderPhotoList"].ToString());
                    DataTable dtOrderPhoto = orderPhoto.Tables["OrderPhoto"];
                    foreach(DataRow rOrderPhoto in dtOrderPhoto.Rows){
                        //upload
                        foreach(var file in Files){
                            if(file.FileName == rOrderPhoto["Name"].ToString()){
                                var dbFileName = UploadedFile(_customer, file.FileName, file);
                                var item = new OrderPhotoModel{
                                    Photo = dbFileName
                                };
                                orderPhotoList.Add(item);
                            }
                        }
                    }
                    //ordertracking
                    List<OrderTrackingModel> orderTrackingList = new List<OrderTrackingModel>();
                    dynamic orderTracking = JsonConvert.DeserializeObject<DataSet>(row["OrderTrackingList"].ToString());
                    DataTable dtOrderTracking = orderTracking.Tables["OrderTracking"];
                    foreach(DataRow rOrderTracking in dtOrderTracking.Rows){
                        var item = new OrderTrackingModel{
                            Code = Helpers.Helpers.RandomCode(),
                            Description = rOrderTracking["Description"].ToString(),
                            BranchId = int.Parse(rOrderTracking["BranchId"].ToString())
                        };
                        orderTrackingList.Add(item);
                    }
                    //productbill
                    List<ProductBillModel> productBillList = new List<ProductBillModel>();
                    dynamic productBill = JsonConvert.DeserializeObject<DataSet>(row["ProductBill"].ToString());
                    DataTable dtProductBill = productBill.Tables["BillProduct"];
                    foreach(DataRow rProductBill in dtProductBill.Rows){
                        var item = new ProductBillModel{
                            CustomerId = customerId,
                            Status = int.Parse(rProductBill["Status"].ToString()),
                            Total = decimal.Parse(rProductBill["Total"].ToString()),
                            PaymentStatus = int.Parse(rProductBill["PaymentStatus"].ToString())
                        };
                        productBillList.Add(item);
                    }
                    //productbilldetail
                    List<ProductBillDetailModel> productBillDetailList = new List<ProductBillDetailModel>();
                    dynamic productList = JsonConvert.DeserializeObject<DataSet>(row["ProductList"].ToString());
                    DataTable dtProductList = productList.Tables["Products"];
                    foreach(DataRow rProductList in dtProductList.Rows){
                        Console.WriteLine(rProductList);
                        var item = new ProductBillDetailModel{
                            ProductId = int.Parse(rProductList["ProductId"].ToString()),
                            Name = rProductList["Name"].ToString(),
                            Code = rProductList["Code"].ToString(),
                            Color = rProductList["Color"].ToString(),
                            Length = rProductList["Length"].ToString(),
                            Width = rProductList["Width"].ToString(),
                            Height = rProductList["Height"].ToString(),
                            Qty = int.Parse(rProductList["Qty"].ToString()),
                            Price = decimal.Parse(rProductList["Price"].ToString()),
                            SubTotal = decimal.Parse(rProductList["SubTotal"].ToString())
                        };
                        productBillDetailList.Add(item);
                    }
                    //bill
                    List<BillModel> billList = new List<BillModel>();
                    dynamic bill = JsonConvert.DeserializeObject<DataSet>(row["Bill"].ToString());
                    DataTable dtBill = bill.Tables["BillDetail"];
                    foreach(DataRow rBill in dtBill.Rows){
                        var item = new BillModel{
                            ServiceId = int.Parse(rBill["ServiceId"].ToString()),
                            ServiceName = rBill["ServiceName"].ToString(),
                            Code = Helpers.Helpers.RandomCode(),
                            IsPickup = rBill["IsPickup"].ToString() == "True" ? true : false,
                            PickUpFee = decimal.Parse(rBill["PickUpFee"].ToString()),
                            Total = decimal.Parse(rBill["Total"].ToString()),
                            PaymentType = int.Parse(rBill["PaymentType"].ToString()),
                            PaymentStatus = int.Parse(rBill["PaymentStatus"].ToString()),
                            BranchId = int.Parse(rBill["BranchId"].ToString())
                        };
                        billList.Add(item);
                    }
                    var _orderCode = Helpers.Helpers.RandomCode();
                    var order = new OrderModel{
                        Code = _orderCode,
                        Length = double.Parse(row["Length"].ToString()),
                        Height = double.Parse(row["Height"].ToString()),
                        Weight = double.Parse(row["Weight"].ToString()),
                        Width = double.Parse(row["Width"].ToString()),
                        //sender
                        SenderId = customerId,
                        SenderFirstName = row["SenderFirstName"].ToString(),
                        SenderLastName = row["SenderLastName"].ToString(),
                        SenderPhone = row["SenderPhone"].ToString(),
                        SenderEmail = row["SenderEmail"].ToString(),
                        CompanyName = row["CompanyName"].ToString(),
                        CompanyPhone = row["CompanyPhone"].ToString(),
                        FromAddress = row["FromAddress"].ToString(),
                        FromWardId = int.Parse(row["FromWardId"].ToString()),
                        FromCityId = int.Parse(row["FromCityId"].ToString()),
                        FromProvinceId = int.Parse(row["FromProvinceId"].ToString()),
                        //receiver
                        //ReceiverId = int.Parse(row["ReceiverId"].ToString()),
                        ReceiverFirstName = row["ReceiverFirstName"].ToString(),
                        ReceiverLastName = row["ReceiverLastName"].ToString(),
                        ReceiverPhone = row["ReceiverPhone"].ToString(),
                        ReceiverEmail = row["ReceiverEmail"].ToString(),
                        ToAddress = row["ToAddress"].ToString(),
                        ToWardId = int.Parse(row["ToWardId"].ToString()),
                        ToCityId = int.Parse(row["ToCityId"].ToString()),
                        ToProvinceId = int.Parse(row["ToProvinceId"].ToString()),
                        //figures
                        PinCode = row["PinCode"].ToString(),
                        DeliveryStatus = int.Parse(row["DeliveryStatus"].ToString()),
                        DeliveryFee = decimal.Parse(row["DeliveryFee"].ToString()),
                        CollectAmount = decimal.Parse(row["CollectedAmount"].ToString()),
                        Notes = row["Notes"].ToString(),
                        Status = int.Parse(row["Status"].ToString()),
                        CreatedAt = DateTime.Now
                    };
                    
                    //create
                    var created = _billService.CreateBill(productBillList, productBillDetailList, 
                                        order, orderDetailList, orderPhotoList, orderTrackingList, billList);
                    if(created != 0) { 
                        orders.Add(created);
                        orderCodes.Add(_orderCode);
                    }
                }    

                if(orders.Count == count){
                    return Ok(new {Code = 200, Message = "Successful", OrderCode = orderCodes});
                } else{
                    return Ok(new {Code = 500, Message = "Something went wrong!"});
                }
            }catch(Exception ex){
                var a = ex.Message;
                throw;
            }
        }

        //tracking
        [HttpGet]
        public List<OrderTrackingModel> GetTrackingByOrder([FromQuery] string orderCode)
        {
            try {
                return _billService.GetOrderTrackings(orderCode) ?? null;
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        //file
        private string UploadedFile(int customerId, string photo, IFormFile blob)
        {
            try
            {
                using (var image = SixLabors.ImageSharp.Image.Load(blob.OpenReadStream()))
                {
                    string folder = "wwwroot/img/customer" + customerId;
                    if(!Directory.Exists(folder)) {
                        Directory.CreateDirectory(folder);
                    }
                    string systemFileExtenstion = photo.Substring(photo.LastIndexOf('.'));
                    var dbFileName = GenerateFileName(systemFileExtenstion);

                    var newfileName = "Photo_" + dbFileName;
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/customer"+customerId)).Root + $@"{newfileName}";
                    image.Save(filepath);

                    return dbFileName; 
                }
            } catch(Exception)
            {
                throw;
            }
        }

        public string GenerateFileName(string fileextenstion)
        {
            if (fileextenstion == null) throw new ArgumentNullException(nameof(fileextenstion));
            return $"{DateTime.Now:yyyyMMddHHmmssfff}_{Guid.NewGuid():N}{fileextenstion}";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
