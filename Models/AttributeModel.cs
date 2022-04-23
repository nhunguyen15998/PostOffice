using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class AttributeModel
    {
        public static Dictionary<int,string> ls_type = new Dictionary<int, string>() { { 1, "color" } , { 2, "length" } , { 3, "width" } , { 4, "height" } };
        [Key]
        public int id { get; set; }
        public string typeName =>ls_type[type];
        public int type { get; set; }
        [Required(ErrorMessage = "* required")]
        [Remote("NameAttrExists", "Attribute", ErrorMessage = "This attribute already exist.")]
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
