using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class AttributeModel
    {
        public static Dictionary<int,string> ls_type = new Dictionary<int, string>() { { 1, "color" } , { 2, "size" } , { 3, "width" } , { 4, "height" } };
        
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        public string typeName =>ls_type[type];
        [Required(ErrorMessage = "* required")]
        public int type { get; set; }
        public DateTime createdAt { get; set; }
    }
}
