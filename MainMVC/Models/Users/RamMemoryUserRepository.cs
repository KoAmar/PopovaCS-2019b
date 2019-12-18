using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainMVC.Models.Users
{
    public class RamMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        private User _currentUser;

        public RamMemoryUserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 0,
                    Email = "",
                    Login = "",
                    Password = "",
                    Role = User.Roles.UnAuthorized
                },
                new User
                {
                    Id = 1,
                    Email = "pavlik@mail.com",
                    Login = "Pavlik",
                    Password = "111111",
                    Role = User.Roles.User
                },
                new User
                {
                    Id = 2,
                    Email = "pa1318vel@gmail.com",
                    Login = "KoAmar",
                    Password = "111123",
                    Role = User.Roles.Admin
                }
            };
            _currentUser = _users[^1];
        }
        
        public bool ContainEmail(string email)
        {
            return FindUserByEmail(email) != null;
        }

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public bool IsLogged()
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            User result = null;
            var emailPattern = @"\w{1,30}@\w{1,30}\.\w{1,15}";
            if (Regex.IsMatch(email, emailPattern))
                foreach (var user in _users)
                    if (user.Email == email)
                        result = user;
            return result;
        }

        public User Register(string email, string login, string password)
        {
            var user = FindUserByEmail(email);
            if (user == null)
                if (IsValidLogin(login))
                    return new User(_users.Max(e => e.Id) + 1, login, email, password);
            return null;
        }

        public User FindUserByEmail(string email)
        {
            User result = null;
            foreach (var user in _users)
                if (user.Email == email)
                    result = user;
            return result;
        }

        public User IsValidUser(string email, string password)
        {
            User result = null;
            var user = FindUserByEmail(email);
            if (user != null)
                if (user.Password == password)
                    result = user;
            return result;
        }

        public static bool IsValidLogin(string login)
        {
            var loginPattern = @"\w{3,20}";
            return Regex.IsMatch(login, loginPattern);
        }

        public void ClearUsers()
        {
            _users.Clear();
        }
    }
}