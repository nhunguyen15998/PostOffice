using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [DefaultValue(null)]
        public char iso3 { get; set; }
        [DefaultValue(null)]
        public char numeric_code { get; set; }
        [DefaultValue(null)]
        public char iso2 { get; set; }
        [DefaultValue(null)]
        public string phonecode { get; set; }
        [DefaultValue(null)]
        public string capital { get; set; }
        [DefaultValue(null)]
        public string currency { get; set; }
        [DefaultValue(null)]
        public string currency_name { get; set; }
        [DefaultValue(null)]
        public string currency_symbol { get; set; }
        [DefaultValue(null)]
        public string tld { get; set; }
        [DefaultValue(null)]
        public string native { get; set; }
        [DefaultValue(null)]
        public string region { get; set; }
        [DefaultValue(null)]
        public string subregion { get; set; }
        [DefaultValue(null)]
        public string timezones { get; set; }
        [DefaultValue(null)]
        public string translations { get; set; }
        [DefaultValue(null)]
        public decimal latitude { get; set; }
        [DefaultValue(null)]
        public decimal longitude { get; set; }
        [DefaultValue(null)]
        public string emoji { get; set; }
        [DefaultValue(null)]
        public string emojiU { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        [DefaultValue(1)]
        public int flag { get; set; }
        [DefaultValue(null)]
        public string wikiDataId { get; set; }

    }
}