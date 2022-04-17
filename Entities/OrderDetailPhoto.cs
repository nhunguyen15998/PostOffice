using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class OrderDetailPhoto
    {
        [Key]
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}