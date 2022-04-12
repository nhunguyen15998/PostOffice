using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epjSem3.Models.ModelViews
{
    public class RolePermissionModel
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public int pmsId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
