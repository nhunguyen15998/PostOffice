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
    public class RoleModel
    {
        // [Column("id", TypeName = "int")]
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "* required")]
        [Remote("CodeRoleExists", "Role", ErrorMessage = "This code already exist.")]
        public string code { get; set; }
        [Required(ErrorMessage = "* required")]
        [Remote("NameRoleExists", "Role", ErrorMessage = "This name already exist.")]
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
