using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    //[Table("users")]
    public class BranchModel
    {
        /*
         *  wardCode varchar
            wardName varchar
            districtCode varchar
            districtName varchar
            provinceCode varchar
            provinceName varchar

*/
        // [Column("id", TypeName = "int")]
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
        [Required(ErrorMessage = "* required")]
        public string address { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }
    }
}
