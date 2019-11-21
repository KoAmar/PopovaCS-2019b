using Microsoft.EntityFrameworkCore;
using MVC_v2.Models.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_v2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Poll> MyProperty { get; set; }
    }
}
