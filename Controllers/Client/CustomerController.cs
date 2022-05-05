using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using post_office.Services;

namespace post_office.Controllers.Client
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private IBillService _billService;
        public CustomerController(ILogger<CustomerController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        public IActionResult MyAccount()
        {        
            ViewBag.Bills = GetBills();
            return View();
        }

        public List<ReadBillModel> GetBills()
        {
            try {
                var customerId = 1;
                return _billService.GetBills(customerId, 0);//, pageIndex ?? 1, pageSize);
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }

        [HttpGet]
        public IActionResult BillDetail(int billId)
        {
            try {
                var customerId = 1;
                var bill = _billService.GetBill(customerId, billId);
                ViewBag.Bill = bill;
                ViewBag.OrderDetails = _billService.GetOrderDetails(bill.OrderId);
                ViewBag.OrderPhotos = _billService.GetOrderPhotos(bill.OrderId);
                if(bill.ProductBillId != null){
                    var productBill = _billService.GetProductBill(bill.ProductBillId);
                    ViewBag.ProductBill = productBill; 
                    ViewBag.ProductBillDetails = _billService.GetProducts(productBill.Id);
                }
                return View();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
