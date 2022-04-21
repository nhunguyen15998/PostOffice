using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class VNState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public char? CountryCode { get; set; }
        [DefaultValue(null)]
        public string fips_code { get; set; }
        [DefaultValue(null)]
        public string iso2 { get; set; }
        [DefaultValue(null)]
        public string type { get; set; }
        [DefaultValue(null)]
        public decimal latitude { get; set; }
        [DefaultValue(null)]
        public decimal longitude { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        [DefaultValue(1)]
        public int flag { get; set; }
        [DefaultValue(null)]
        public string wikiDataId { get; set; }

    }
}