using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        [DefaultValue(1)]
        public int Qty { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Order Order { get; set; }
    }
}