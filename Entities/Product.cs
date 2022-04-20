using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

        public ProductCategory Category { get; set; }
    }
}