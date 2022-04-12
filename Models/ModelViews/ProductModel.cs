using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        public int categoryId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "The field quantity must be a number.")]
        [Required(ErrorMessage = "* required")]
        public int qty { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid price (start at least is 1)")]
        public decimal? price { get; set; }
        public int branchId { get; set; }
        [Required(ErrorMessage = "* required")]
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }

        //list attr public List<ProductAttribute> ls 
    }
}
