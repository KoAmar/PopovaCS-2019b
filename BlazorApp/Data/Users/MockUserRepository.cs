using BlazorApp.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        private User ContainEmail(string email)
        {
            foreach (var user in _users)
            {
                if (user.Email == email) { return user; }
            }
            return null;
        }

        private User IsValid(string email, string password)
        {
            var user = ContainEmail(email);
            if (user != null)
            {
                if (user.PasswordHash == password)
                {
                    return user;
                }
            }
            return null;
        }

        public User Login(string email, string password)
        {
            string emailPattern = @"\w{30}@\w{30}";
            string passwordPattern = @"\w{6-64}";

            if (Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase) & Regex.IsMatch(password, passwordPattern, RegexOptions.IgnoreCase))
            {
                var user = IsValid(email, password);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public User Register(string email, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
