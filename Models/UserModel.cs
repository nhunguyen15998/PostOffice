using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class UserModel
    {

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
        //email

        [Required(ErrorMessage = "* required")]
        [RegularExpression("[a-zA-Z0-9][a-zA-Z0-9._]*@[a-zA-Z0-9-]+([.][a-zA-Z]+)+", ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        //password
        [Required(ErrorMessage = "* required")]
        [MinLength(6, ErrorMessage = "Field password needs a minimum of 6 characters")]
        public string password { get; set; }

        //avt

        public string avatar { get; set; }

        //role id
        public int roleId { get; set; } 
        
        //branch id
        public int branchId { get; set; }

        //created at
        public DateTime createdAt { get; set; }

        //status
        public int status { get; set; } 
        
        public string branch { get; set; }
        public string role { get; set; }
        
    }
}
