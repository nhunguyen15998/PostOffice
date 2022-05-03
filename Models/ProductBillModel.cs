using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ProductBillModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public decimal Total { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int PaymentStatus { get; set; }

    }

    public class ProductBillDetailModel
    {
        public int Id { get; set; }
        public int ProductBillId { get; set; }
        public int? ProductAttributeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    
}
