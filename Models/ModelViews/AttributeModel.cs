using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class AttributeModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "* required")]
        public string name { get; set; }
        [Required(ErrorMessage = "* required")]
        public string typeName { get; set; }
        [Required(ErrorMessage = "* required")]
        public int type { get; set; }
        [Required(ErrorMessage = "* required")]
        public DateTime createdAt { get; set; }
    }
}
