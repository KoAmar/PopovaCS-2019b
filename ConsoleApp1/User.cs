using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ConsoleApp1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UsersDbContext : DbContext
    {
        public UsersDbContext() : base("BbContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
