﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using post_office.Entities;
using post_office.Helpers;
using post_office.Models;

namespace post_office.Services
{

    public interface IRoleService
    {
        RoleModel SaveRole(RoleModel mdl);
        List<RoleModel> GetListRole();
        List<RolePermissionModel> GetListRolePermission();
        bool ModifyRole(RoleModel model);
        List<PermissionModel> GetListPermission();
        void RemoveRolePermission(int mdl);
        void CreateRolePermission(RolePermissionModel mdl);
        bool RemoveRole(List<int> ls);
        RoleModel GetRole(int id);
    }
    public class RoleService : IRoleService
    {
        private DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }
        public RoleModel SaveRole(RoleModel mdl)
        {
            _context.Add(new Role() { Code = mdl.code, Name = mdl.name, CreatedAt = DateTime.Now });
            _context.SaveChanges();
            return mdl;
        }
        public bool ModifyRole(RoleModel mdl)
        {
            var w = _context.Roles.FirstOrDefault(x => x.Id == mdl.id);
            if (w != null)
            {
                w.Name = mdl.name;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    
        public List<RoleModel> GetListRole()
        {
            return _context.Roles.Select(x => new RoleModel() { id = x.Id, name = x.Name, code = x.Code, createdAt = (DateTime)x.CreatedAt }).ToList();
        }
        public List<RolePermissionModel> GetListRolePermission()
        {
            return _context.RolePermissions.Select(x => new RolePermissionModel() { id = x.Id, pmsId = x.PermissionId, roleId = x.RoleId, createdAt = (DateTime)x.CreatedAt }).ToList();
        }
        public List<PermissionModel> GetListPermission()
        {
            return _context.Permissions.Select(x => new PermissionModel() { id = x.Id, code = x.Code, name = x.Name, createdAt = (DateTime)x.CreatedAt }).ToList();

        }
        public void RemoveRolePermission(int mdl)
        {
            var w = _context.RolePermissions.FirstOrDefault(x => x.PermissionId == mdl);
            if (w != null)
            {
                _context.RolePermissions.Remove(w);
                _context.SaveChanges();
            }

        }
        public void CreateRolePermission(RolePermissionModel mdl)
        {
           
                _context.RolePermissions.Add(new RolePermission() {PermissionId=mdl.pmsId, RoleId=mdl.roleId, CreatedAt=mdl.createdAt});
                _context.SaveChanges();
        }
        public RoleModel GetRole(int id)
        {
          return   _context.Roles.Select(x => new RoleModel() { id = x.Id, name = x.Name, code = x.Code, createdAt = (DateTime)x.CreatedAt }).FirstOrDefault(x => x.id == id);

        }
        public bool RemoveRole(List<int> ls)
        {
            bool check = true;
            foreach (var item in ls)
            {
                var r = _context.Roles.SingleOrDefault(x => x.Id == item);
                if (r != null)
                {
                    var user = _context.Users.FirstOrDefault(x => x.RoleId == r.Id);
                    if (user == null)
                    {
                        _context.Roles.Remove(r);
                        _context.SaveChanges();
                    }
                    else
                    {
                        check = false;
                    }
                }
            }
            return check;
        }
    }

}
