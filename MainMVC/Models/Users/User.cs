using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MainMVC.Models.Users
{
    public class User
    {
        public User()
        {
        }

        public User(int id, string login, string email, string password)
        {
            Id = id;
            Login = login;
            Email = email;
            Role = Roles.UnAuthorized;
            Password = password;
        }

        public enum Roles
        {
            UnAuthorized,
            User,
            Admin
        }

        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is User that)
            {
                return Id == that.Id &&
                       Login == that.Login &&
                       Email == that.Email &&
                       Role == that.Role &&
                       Password == that.Password;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Login, Email, Role, Password);
        }
    }
}
