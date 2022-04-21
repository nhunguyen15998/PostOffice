using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ServiceModel
    {
        public static Dictionary<int, string> ls_status = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };

        [Key]
        public int id { get; set; }
        
        //name
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }

        //price
        [Required(ErrorMessage = "* required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid price (start at least is 1)")]
        public decimal price { get; set; }

        //slot
        [Required(ErrorMessage = "* required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "The field slot must be a number > 0")]
        public int slot { get; set; }

        //content
        [Required(ErrorMessage = "* required")]
        public string content { get; set; }

        //created at
        public DateTime createdAt { get; set; }

        //status
        public int status { get; set; }
    }
}
