using System;
using System.ComponentModel;

namespace post_office.Entities
{
    public class VNCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
        [DefaultValue(null)]
        public string StateCode { get; set; }
        public int? CountryId { get; set; }
        public char CountryCode { get; set; }


    }
}