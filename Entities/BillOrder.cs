using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class BillOrder
    {
        [Key]
        public int Id { get; set; }
        public int BillId { get; set; }
        public int OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

        public Bill Bill { get; set; }
        public Order Order { get; set; }
    }
}