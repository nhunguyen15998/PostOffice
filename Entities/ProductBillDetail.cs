using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class ProductBillDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProductBillId { get; set; }
        public int ProductId { get; set; }
        public string Photo { get; set; }
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

        public ProductBill ProductBill { get; set; }
        public Product Product { get; set; }
    }
}