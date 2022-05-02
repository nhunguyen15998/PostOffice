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
        public IActionResult CreateBill([FromForm] List<OrderModel> orders, List<OrderDetailModel> orderDetails, 
                                        List<OrderPhotoModel> orderPhotos, OrderTrackingModel orderTracking,
                                        ProductBillModel productBill, List<ProductBillDetailModel> productBillDetails,
                                        BillModel bill)
        {
            try {
                //order
                //order detail
                //order photo
                
                //order tracking

                //product bill
                //product bill detail

                //bill
                //bill order
                _billService.CreateBill(productBill, productBillDetails, 
                                        orders, orderDetails, orderPhotos, orderTracking, 
                                        bill);
                return Ok();
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
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/customer"+customerId)).Root + $@"\{newfileName}";
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
