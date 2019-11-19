using BlazorApp.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Users
{
    interface IUserRepository
    {
        public User Login(string email, string password);
        public User Register(string email, string login, string password);
    }
}
