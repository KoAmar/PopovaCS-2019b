using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_v2.Models.Users
{
    public class User
    {
        public User()
        {
        }

        public User(int id, string login, string email, string passwordHash)
        {
            Id = id;
            Login = login;
            Email = email;
            Role = Roles.UnAuthorized;
            PasswordHash = passwordHash;
        }

        public enum Roles
        {
            UnAuthorized,
            User,
            Moderator,
            Admin
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public string PasswordHash { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                var that = obj as User;
                return Id == that.Id && Login == that.Login && Email == that.Email && Role == that.Role && PasswordHash == that.PasswordHash;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Login, Email, Role, PasswordHash);
        }
    }
}
