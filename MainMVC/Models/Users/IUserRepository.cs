using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Users
{
    public interface IUserRepository
    {

        User Login(User user);
        User Register(User user);
        User GetCurrentUser();
        bool IsLogged();
        void Logout();
        IEnumerable<User> GetUsers();

        IEnumerable<User> SetUsers(IEnumerable<User> users);
    }
}
