using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int? ProductBillId { get; set; }
        public int ServiceId { get; set; }

        public decimal? PickUpFee { get; set; }
        [DefaultValue(false)]
        public bool IsPickup { get; set; }
        public DateTime? SendingOn { get; set; }

        [DefaultValue(1)]
        public int OrderQty { get; set; }
        public decimal Total { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? PaidOn { get; set; }
        public int BranchId { get; set; }

        public ProductBill ProductBill { get; set; }
    }
}