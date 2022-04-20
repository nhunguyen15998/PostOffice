using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Ward
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int city_id { get; set; }
        [DefaultValue(null)]
        public string city_code { get; set; }
        public int state_id { get; set; }
        [DefaultValue(null)]
        public string state_code { get; set; }
        public int country_id { get; set; }
        [DefaultValue(null)]
        public string country_code { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Status { get; set; }

    }
}