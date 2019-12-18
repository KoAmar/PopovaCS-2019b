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
        bool ContainEmail(string email);
        User GetCurrentUser();
        bool IsLogged();
    }
}
