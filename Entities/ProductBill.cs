using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class ProductBill
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int PaymentStatus { get; set; }

        public Customer Customer { get; set; }
    }
}