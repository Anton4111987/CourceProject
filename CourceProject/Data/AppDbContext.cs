using Microsoft.EntityFrameworkCore;

namespace CourceProject.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Products { get; set; }

        public DbSet<Account> Accountss { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }



    }
}
