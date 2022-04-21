using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class DefaultCountries
    {
        public static int Vietnam = 240;
        public static int UnitedStates = 233;
        public static int India = 101;
        public static int Australia = 14;
        public static List<int> countryIds = new List<int>{
                DefaultCountries.Vietnam,
                DefaultCountries.UnitedStates,
                DefaultCountries.India
        };
    }

    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PinCode { get; set; }
    }
}
