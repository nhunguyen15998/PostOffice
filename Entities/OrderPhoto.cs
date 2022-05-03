using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class OrderPhoto
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Order Order { get; set; }
    }
}