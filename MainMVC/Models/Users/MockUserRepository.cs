using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MainMVC.Models.Users
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
                    PasswordHash = "111111",
                    Role = User.Roles.User
                },
                new User{
                    Id = 2,
                    Email = "pa1318vel@gmail.com",
                    Login = "KoAmar",
                    PasswordHash = "111123",
                    Role = User.Roles.Admin
                },
            };
        }

        public bool ContainEmail(string email)
        {
            return FindUserByEmail(email) != null;
        }

        public User FindUserByEmail(string email)
        {
            User result = null;
            foreach (var user in _users)
            {
                if (user.Email == email) { result = user; }
            }
            return result;
        }

        public User IsValidUser(string email, string password)
        {
            User result = null;
            var user = FindUserByEmail(email);
            if (user != null)
            {
                if (user.PasswordHash == password)
                {
                    result = user;
                }
            }
            return result;
        }

        public int StrongPassword(string password)
        {
            int result = 0;

            if (password.Length >= 6)
            {
                result++;
                if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
                    Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                {
                    result++;
                    if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        public bool IsValidLogin(string login)
        {
            string loginPattern = @"\w{3,20}";
            return Regex.IsMatch(login, loginPattern);
        }

        public User Login(string email, string password)
        {
            User result = null;
            string emailPattern = @"\w{1,30}@\w{1,30}\.\w{1,15}";
            string passwordPattern = @"\w{6,64}";
            if (Regex.IsMatch(email, emailPattern) && Regex.IsMatch(password, passwordPattern))
            {
                var user = IsValidUser(email, password);
                if (user != null)
                {
                    result = user;
                }
            }
            return result;
        }

        public User Register(string email, string login, string password)
        {
            var user = FindUserByEmail(email);
            if (user == null)
            {
                if (IsValidLogin(login))
                {
                    return new User(_users.Max(e => e.Id) + 1, login, email, password);
                }
            }
            return null;
        }
    }
}
