using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class UserModel
    {
        public static Dictionary<int, string> ls_sts = new Dictionary<int, string>() { { 1, "Activated" }, { 2, "Deactivated" }, { 3, "status 3" }, { 4, "status 4" } };

        [Key]
        public int id { get; set; }

        //code
        public string code { get; set; }

        //name
        [Required(ErrorMessage = "* required")]
        public string fullName { get; set; }
        //phone
        [Required(ErrorMessage = "* required")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }


        //password
        [Required(ErrorMessage = "* required")]
        [MinLength(6, ErrorMessage = "Field password needs a minimum of 6 characters")]
        public string password { get; set; }

        //role id
        public int roleId { get; set; } 
        
        //branch id
        public int branchId { get; set; }

        //created at
        public DateTime createdAt { get; set; }

        //status
        public int status { get; set; } 
        
        
    }
}
