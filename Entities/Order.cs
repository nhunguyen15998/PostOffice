using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }

        public int SenderId { get; set; }
        public string FromAddress { get; set; }
        public int FromWardId { get; set; }
        public int FromDistrictId { get; set; }
        public int FromCityId { get; set; }
        public int FromProvinceId { get; set; }

        public int ReceiverId { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ToAddress { get; set; }
        public int ToWardId { get; set; }
        public int ToDistrictId { get; set; }
        public int ToCityId { get; set; }
        public int ToProvinceId { get; set; }
        public string PinCode { get; set; }

        public int DeliveryStatus { get; set; }
        public decimal DeliveryFee { get; set; }
        public DateTime? DeliveryOn { get; set; }

        public decimal? CollectAmount { get; set; }
        public decimal? TotalOrder { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Customer Sender { get; set; }
        public Customer Receiver { get; set; }
    }
}