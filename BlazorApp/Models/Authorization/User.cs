using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models.Authorization
{
    public class User
    {
        public enum Roles
        {
            UnAuthorized,
            User,
            Moderator,
            Admin
        }

        public int StudentId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
