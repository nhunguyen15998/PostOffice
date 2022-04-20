﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class ProductModel
    {
        public static Dictionary<int, string> ls_status = new Dictionary<int, string>() { { 1, "Activated" }, { 0, "Deactivated" } };


        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int? categoryId { get; set; }
        public int? qty { get; set; }
        public decimal? price { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public int status { get; set; }

        public IFormFile Thumbnail { get; set; }
    }
}
