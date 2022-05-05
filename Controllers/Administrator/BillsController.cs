using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using post_office.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Controllers.Administrator
{
    public class BillsController : Controller
    {
        private readonly ILogger<BillsController> _logger;
        private IBillService _billService;
        public BillsController(ILogger<BillsController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
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

        public IActionResult BillDetail()
        {
            if (AuthenticetionModel.id != 0)
            {
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

        [HttpGet]
        public IActionResult BillDetail(int billId)
        {
            try {
                // var bill = _billService.GetBill(0, billId);
                // ViewBag.Bill = bill;
                // ViewBag.OrderDetails = _billService.GetOrderDetails(bill.OrderId);
                // ViewBag.OrderPhotos = _billService.GetOrderPhotos(bill.OrderId);
                // if(bill.ProductBillId != null){
                //     var productBill = _billService.GetProductBill(bill.ProductBillId);
                //     ViewBag.ProductBill = productBill; 
                //     ViewBag.ProductBillDetails = _billService.GetProducts(productBill.Id);
                // }
                return View();
            } catch(Exception ex) {
                var a = ex.Message;
                throw;
            }
        }
    }
}
