using BlazorApp.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Users
{
    public class MockUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>(){
                new User{
                    Id = 0,
                    Email = "",
                    Login = "",
                    PasswordHash = "",
                    Role = User.Roles.UnAuthorized
                },
                new User{
                    Id = 1,
                    Email = "pavlik@mail.com",
                    Login = "Pavlik",
                    PasswordHash = "1111",
                    Role = User.Roles.User
                },
                new User{
                    Id = 2,
                    Email = "pa1318vel@gmail.com",
                    Login = "KoAmar",
                    PasswordHash = "1111",
                    Role = User.Roles.Admin
                },
            };
        }

        public bool IsValid(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Register(string email, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
