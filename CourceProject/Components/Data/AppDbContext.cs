using Microsoft.EntityFrameworkCore;
using CourceProject.Components.Models;

namespace CourceProject.Components.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Confidant> Confidants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
