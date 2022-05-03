using Microsoft.AspNetCore.Mvc;
using post_office.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ContactModel
    {
        [Key]
        public int id { get; set; }

        //name
        [Required(ErrorMessage = "Field name is required")]
        public string name { get; set; }
        //phone
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }
        //email

        [Required(ErrorMessage = "Field Email is required")]
        [RegularExpression("[a-zA-Z0-9][a-zA-Z0-9._]*@[a-zA-Z0-9-]+([.][a-zA-Z]+)+", ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        //subject
        [Required(ErrorMessage = "Field Subject is required")]
        public string subject { get; set; }

        //message
        [Required(ErrorMessage = "Field Message is required")]
        public string message { get; set; }
        //isRead
        public bool isRead { get; set; } 
        //isReply
        public bool isReply { get; set; }
        //replierID
        public int? ReplierId { get; set; }
        //created at
        public DateTime createdAt { get; set; }
        public User replier { get; set; }


    }
}
