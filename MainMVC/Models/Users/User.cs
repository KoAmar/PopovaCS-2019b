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
            Id = 0;
            Login = "Constructor";
            Email = "Constuctor@Constuctor.by";
            Password = "ConstructorConstructorConstructor";
            Role = Roles.UnAuthorized;
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
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"\w{1,30}@\w{1,30}\.\w{1,15}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
