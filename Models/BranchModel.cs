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
        [Remote("CodeBranchExists", "Branch", ErrorMessage = "This code already exist.")]
        public string code { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        [Required(ErrorMessage = "* required")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Invalid phone number")]
        [Remote("PhoneBranchExists", "Branch", ErrorMessage = "This phone already exist.")]
        public string phone { get; set; }
        public int headUserID { get; set; }
        public string headUserName { get; set; }
        [Required(ErrorMessage = "* required")]
        public string address { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage =" * required")]
        public int wardId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = " * required")]
        public int cityId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = " * required")]
        public int provinceId { get; set; }
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
        public int? wardId { get; set; }
        public string wardName { get; set; }
        public int? cityId { get; set; }
        public string cityName { get; set; }
        public int? provinceId { get; set; }
        public string provinceName { get; set; }
        public DateTime? createdAt { get; set; }
        public int status { get; set; }
        public string statusValue { get; set; }
    }
}
