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

        //content
        [Required(ErrorMessage = "* required")]
        public string content { get; set; }

        //created at
        public DateTime createdAt { get; set; }

        //status
        public int status { get; set; }
    }
}
