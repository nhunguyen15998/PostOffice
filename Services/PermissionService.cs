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
    }
}
