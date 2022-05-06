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
        //setup true: forgot password, my account .false: update info user
        bool ModifyUser(UserModel mdl, bool setup);
        UserModel GetUser(int id);
        bool ChangeStatusListUser(List<int> ls, int status);
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
            int brnId = mdl.branchId;
            if (AuthenticetionModel.roleName != "Super Admin")
                brnId = AuthenticetionModel.branchId;

            var w = new User()
            {
                Avatar = mdl.avatar,
                BranchId = brnId,
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
            _context.SaveChanges();
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
            return _context.Users.Select(x => new UserModel() { id = x.Id, email=x.Email, avatar = x.Avatar, branchId = x.BranchId ?? 0, code = x.Code, fullName = x.FullName, password = x.Password, createdAt = (DateTime)x.CreatedAt, phone = x.Phone, roleId = (int)x.RoleId, status = x.Status, role=x.Role.Name, branch=x.Branch.Name}).ToList();
        }
        public bool ModifyUser(UserModel u, bool setup)
        {
            //setup true: forgot password, my account .false: update info user
            var us = _context.Users.FirstOrDefault(x => x.Id == u.id);

            if (us != null)
            {
                if (setup || AuthenticetionModel.roleName == "Super Admin" )
                {
                    us.Password = u.password;
                    us.Phone = u.phone;
                }
                us.FullName = u.fullName;
                us.Email = u.email;
                us.BranchId = u.branchId==0?null:u.branchId;
                us.RoleId = u.roleId;
                us.Status = u.status;
                us.Avatar = u.avatar;
                if (us.Id == AuthenticetionModel.id&&u.status==0) return false;
                _context.SaveChanges();
            }
            return true; 
        }
        public UserModel GetUser(int id)
        {
            var w= _context.Users.Select(x => new UserModel() { id = x.Id, createdBy =  x.CreatedBy??0, email = x.Email, avatar = x.Avatar==null?"":x.Avatar, branchId = x.BranchId ?? 0, code = x.Code, fullName = x.FullName, password = x.Password, createdAt = (DateTime)x.CreatedAt, phone = x.Phone, roleId = (int)x.RoleId, status = x.Status, role = x.Role.Name, branch = x.Branch.Name }).FirstOrDefault(x => x.id == id);
            if (w.createdBy == 0) w.createdByString = "**SYSTEM**"; else w.createdByString = _context.Users.SingleOrDefault(y => y.Id == w.createdBy).FullName + " - Code: " + _context.Users.SingleOrDefault(y => y.Id == w.createdBy).Code;
            return w;
        }
        public bool  ChangeStatusListUser(List<int> ls, int status) {
            bool check = true;
            foreach (var item in ls)
            {
                var us = _context.Users.SingleOrDefault(x => x.Id == item);
                if (us != null)
                {
                    if (us.Id == AuthenticetionModel.id && status == 0) { check = false;}
                    else if (us.Status != status) us.Status = status;
                    _context.SaveChanges();
                    
                }


            }
            return check;
        }

    }
}
