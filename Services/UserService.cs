using post_office.Entities;
using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IUserService
    {
        UserModel SaveUser(UserModel mdl);
        UserModel LoginAction(string uName, string psw);
        List<UserModel> GetListUser();
        bool ModifyUser(UserModel mdl);
    }
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public UserModel SaveUser(UserModel mdl)
        {
            var w = new User()
            {
                Avatar = mdl.avatar,
                BranchId = mdl.branchId,
                Code = Helpers.Helpers.RandomCode(),
                CreatedAt = DateTime.Now,
                CreatedBy = AuthenticetionModel.id,
                Email = mdl.email,
                FullName = mdl.fullName,
                Password = BCrypt.Net.BCrypt.HashPassword(mdl.password),
                 Phone=mdl.phone,
                 RoleId=mdl.roleId,
                 Status=mdl.status
            
            };
            _context.Users.Add(w);
            mdl.id = w.Id;
            return mdl;
        }

        public UserModel LoginAction(string user, string pass)
        {

            UserModel d = _context.Users.Select(x=>new UserModel() {id=x.Id, email = x.Email, avatar =x.Avatar, branchId=x.BranchId??0,code=x.Code,fullName=x.FullName, password=x.Password, createdAt=(DateTime)x.CreatedAt, phone=x.Phone, roleId=(int)x.RoleId, status=x.Status}).FirstOrDefault(x => x.phone == user && x.status == 1);

            if (d != null && BCrypt.Net.BCrypt.Verify(pass, d.password) == true)
            {
                return d;
            }

            return null;
        }
        public List<UserModel> GetListUser()
        {
            return _context.Users.Select(x => new UserModel() { id = x.Id,email=x.Email, avatar = x.Avatar, branchId = x.BranchId ?? 0, code = x.Code, fullName = x.FullName, password = x.Password, createdAt = (DateTime)x.CreatedAt, phone = x.Phone, roleId = (int)x.RoleId, status = x.Status, role=_context.Roles.FirstOrDefault(y=>y.Id==x.RoleId).Name, branch=_context.Branches.FirstOrDefault(z=>z.Id==x.BranchId).Name }).ToList();
        }
        public bool ModifyUser(UserModel u)
        {
            var us = _context.Users.FirstOrDefault(x => x.Id == u.id);

            if (us != null)
            {
                us.Password = u.password;
                us.Phone = u.phone;
                us.FullName = u.fullName;
                us.Status = u.status;
                us.Avatar = u.avatar;
                if (us.Id == AuthenticetionModel.id&&us.Status==0) return false;
                _context.SaveChanges();
                return true;
            }
            return true; 
        }
    }
}
