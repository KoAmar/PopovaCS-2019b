using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MainMVC.Models.Users
{
    public class RamMemoryUserRepository : IUserRepository
    {
        private List<User> _users;

        private User _currentUser;

        public RamMemoryUserRepository()
        {
            _users = new List<User>
            {
                new User(),
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
                    Password = "111111",
                    Role = User.Roles.Admin
                }
            };
            _currentUser = _users[0];
        }

        public bool ContainEmail(string email)
        {
            return FindUserByEmail(email) != null;
        }

        public User GetCurrentUser()
        {
            var userCopy = _currentUser;
            userCopy.Password = "_not_a_password_";
            return userCopy;
        }

        public bool IsLogged()
        {
            return _currentUser.Role != User.Roles.UnAuthorized;
        }

        public IEnumerable<User> GetUsers()
        {
            var newUsers = new List<User>(_users);
            return newUsers;
        }

        public IEnumerable<User> SetUsers(IEnumerable<User> users)
        {
            _users.Clear();
            foreach (var user in users)
            {
                _users.Add(user);
            }
            return _users;
        }

        public User Login(User user)
        {
            User result = null;
            const string emailPattern = @"\w{1,30}@\w{1,30}\.\w{1,15}";
            if (!Regex.IsMatch(user.Email, emailPattern)) return null;

            foreach (var dbUser in _users)
                if (user.Email == dbUser.Email && user.Password == dbUser.Password)
                {
                    result = dbUser;
                    _currentUser = dbUser;
                }

            return result;
        }

        public User Register(User newUser)
        {
            var user = FindUserByEmail(newUser.Email);
            if (user != null) return null;
            newUser.Id = _users.Max(e => e.Id) + 1;
            newUser.Role = User.Roles.User;

            _users.Add(newUser);
            _currentUser = newUser;
            return newUser;
        }

        private User FindUserByEmail(string email)
        {
            User result = null;
            foreach (var user in _users)
                if (user.Email == email)
                    result = user;
            return result;
        }

        public void ClearUsers()
        {
            _users.Clear();
        }
    }
}