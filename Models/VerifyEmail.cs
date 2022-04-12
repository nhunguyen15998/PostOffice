using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models
{
    public class VerifyEmail
    {
        public VerifyEmail()
        {

        }
        public int id { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public DateTime createdAt { get; set; }
        public bool status { get; set; }

    }
}
