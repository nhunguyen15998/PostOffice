using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public int? qty { get; set; }
        public decimal? price { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }

        //list attr public List<ProductAttribute> ls 
    }
}
