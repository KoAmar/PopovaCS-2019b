using MainMVC.Models.Polls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainMVC.Models.Polls.Entities;
using MainMVC.Models.Users;

namespace MainMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<MainMVC.Models.Polls.Entities.Question> Question { get; set; }

        public DbSet<MainMVC.Models.Users.User> User { get; set; }
    }
}