using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models
{
    public class Helpers
    {
        public static string RandomCode()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
