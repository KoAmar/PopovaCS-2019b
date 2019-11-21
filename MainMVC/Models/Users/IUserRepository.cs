using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_v2.Models.Users
{
    interface IUserRepository
    {
        public User Login(string email, string password);
        public User Register(string email, string login, string password);
    }
}
