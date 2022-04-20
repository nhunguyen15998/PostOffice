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
    }
    public class UserService : IUserService
    {
        public UserModel SaveUser(UserModel mdl)
        {
            return null;
        }
    }
}
