using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class ProductPhoto
    {
        [Key]
        public int Id { get; set; }
        public int ProductAttributeId { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}