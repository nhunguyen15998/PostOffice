using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class BranchModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "* required")]
        [Remote("CodeBrandExists", "Auth", ErrorMessage = "This code already exist.")]
        public string code { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        [Required(ErrorMessage = "* required")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }
        public int headUserID { get; set; }
        public string headUserName { get; set; }
        [Required(ErrorMessage = "* required")]
        public string address { get; set; }
        public string wardId { get; set; }
        public string cityId { get; set; }
        public string provinceId { get; set; }
        public string countryId { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }
    }

    public class ReadBranchModel
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int headUserID { get; set; }
        public string headUserName { get; set; }
        public string address { get; set; }
        public string wardName { get; set; }
        public string cityName { get; set; }
        public string provinceName { get; set; }
        public string countryName { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }
        public string statusValue { get; set; }
    }
}
