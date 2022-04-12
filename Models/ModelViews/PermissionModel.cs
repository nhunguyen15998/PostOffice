using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class PermissionModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
    }
}
