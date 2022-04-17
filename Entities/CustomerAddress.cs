using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace post_office.Entities
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [DefaultValue(false)]
        public bool IsCompany { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string Address { get; set; }
        public int WardId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        [DefaultValue(true)]
        public bool IsDefault { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Customer Customer { get; set; }
    }
}