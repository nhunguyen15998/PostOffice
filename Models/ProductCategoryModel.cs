using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ProductCategoryModel
    {
        public static Dictionary<int, string> ls_status = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" }};

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }
    }
}
