using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace post_office.Models
{
    public class CustomerSignUpModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class CustomerSignInModel
    {
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class CustomerModel
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "* required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* required")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "* required")]
        [RegularExpression("[a-zA-Z0-9][a-zA-Z0-9._]*@[a-zA-Z0-9-]+([.][a-zA-Z]+)+", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }

    }
}