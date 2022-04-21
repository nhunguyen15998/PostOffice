using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class VNWard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        [DefaultValue(null)]
        public string CityCode { get; set; }
        public int? StateId { get; set; }
        [DefaultValue(null)]
        public string StateCode { get; set; }
        public int? CountryId { get; set; }
        [DefaultValue(null)]
        public string CountryCode { get; set; }

    }
}