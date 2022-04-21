using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set;}
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

        public ProductCategory Parent { get; set; }
    }
}