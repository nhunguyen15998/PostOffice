using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class OrderTracking
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public int ShipperId { get; set; }
        public int BranchId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Order Order { get; set; }
        public User Shipper { get; set; }
        public Branch Branch { get; set; }
    }
}