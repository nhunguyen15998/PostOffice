using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ProductAttributeModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int? colorID { get; set; }
        public string colorValue { get; set; }
        public int? lengthID { get; set; }
        public string lengthValue { get; set; }
        public int? widthID { get; set; }
        public string widthValue { get; set; }
        public int? heightID { get; set; }
        public string heightValue { get; set; }
        public int qty { get; set; }
        public decimal price { get; set; }
        public DateTime createAt { get; set; }

    }
}
