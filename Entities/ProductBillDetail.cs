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
        public int ProductAttributeId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

        public ProductBill ProductBill { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}