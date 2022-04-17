using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class ProductAttribute
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? WidthId { get; set; }
        public int? LengthId { get; set; }
        public int? HeightId { get; set; }
        public int? Qty { get; set; }
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Product Product { get; set; }
        public Attribute Color { get; set; }
        public Attribute Width { get; set; }
        public Attribute Length { get; set; }
        public Attribute Height { get; set; }

    }
}