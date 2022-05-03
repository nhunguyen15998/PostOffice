using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int OrderId { get; set; }
        public int? ProductBillId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        
        public decimal? PickUpFee { get; set; }
        public bool IsPickup { get; set; }
        public DateTime? SendingOn { get; set; }

        public decimal Total { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? PaidOn { get; set; }
        public int BranchId { get; set; }
    }

    
}
