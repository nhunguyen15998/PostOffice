using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }

        //sender
        public int SenderId { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string FromAddress { get; set; }
        public int FromWardId { get; set; }
        public int FromCityId { get; set; }
        public int FromProvinceId { get; set; }

        //receiver
        public int? ReceiverId { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverPhone { get; set; }
        public string ToAddress { get; set; }
        public int ToWardId { get; set; }
        public int ToCityId { get; set; }
        public int ToProvinceId { get; set; }
        public string PinCode { get; set; }

        public int DeliveryStatus { get; set; }
        public decimal DeliveryFee { get; set; }
        public DateTime? DeliveryOn { get; set; }

        public decimal? CollectAmount { get; set; }
        public string Notes { get; set; }

        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<OrderDetailModel> OrderDetailList { get; set; }  
        public List<OrderPhotoModel> OrderPhotoList { get; set; } 
        public List<OrderTrackingModel> OrderTrackingList { get; set; }         
    }

    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderPhotoModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderTrackingModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int? ShipperId { get; set; }
        public int BranchId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    
}
