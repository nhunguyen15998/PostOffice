using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IPermissionService
    {
        List<PermissionModel> GetListPermission();
        List<PermissionModel> GetListPermissionByRoleID(int rid);
    }
    public class PermissionService : IPermissionService
    {
        private DataContext _context;

        public PermissionService(DataContext context)
        {
            _context = context;
        }
        public List<PermissionModel> GetListPermission()
        {
            return _context.Permissions.Select(x => new PermissionModel() { id = x.Id, code = x.Code, name = x.Name, createdAt = (DateTime)x.CreatedAt }).ToList();

        }
        public List<PermissionModel> GetListPermissionByRoleID(int rid)
        {
            var w =_context.RolePermissions.Where(x=>x.RoleId==rid).Select(x=>x.PermissionId).ToList();
            List<PermissionModel> res = new List<PermissionModel>();
            foreach (var item in w)
            {
                var pms = _context.Permissions.Where(x => x.Id == item);
                foreach (var item1 in pms)
                {
                    res.Add(new PermissionModel() { id = item1.Id, code = item1.Code, name = item1.Name, createdAt = (DateTime)item1.CreatedAt });
                }

            }
            return res;

        }
    }
}
