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
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? PaidOn { get; set; }
        public int BranchId { get; set; }
    }

    public class ReadBillModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int OrderId { get; set; }
        public int? ProductBillId { get; set; }

        //sender
        public int SenderId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string FromAddress { get; set; }
        public string FromWard { get; set; }
        public string FromCity { get; set; }
        public string FromProvince { get; set; }

        //receiver
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public string ToAddress { get; set; }
        public string ToWard { get; set; }
        public string ToCity { get; set; }
        public string ToProvince { get; set; }
        public string PinCode { get; set; }
        //
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        //date
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeliveryOn { get; set; }
        public DateTime? PaidOn { get; set; }
        public string ServiceName { get; set; }
        
        public decimal? PickUpFee { get; set; }
        public bool IsPickup { get; set; }
        public DateTime? SendingOn { get; set; }
        public int DeliveryStatus { get; set; }
        public decimal DeliveryFee { get; set; }

        public decimal? CollectAmount { get; set; }
        public string Notes { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public decimal Total { get; set; }
        public int Status { get; set; }
    }
    
}
