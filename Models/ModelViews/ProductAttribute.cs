using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class ProductAttribute
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int attrId { get; set; }
        public decimal price { get; set; }
        public DateTime createAt { get; set; }

     


    }
}
