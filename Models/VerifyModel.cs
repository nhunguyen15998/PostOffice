using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class VerifyModel
    {
        public string email { get; set; }
        public string verify_code { get; set; }
        public DateTime created_at { get; set; }
        public bool isForUser { get; set; }
    }
}
