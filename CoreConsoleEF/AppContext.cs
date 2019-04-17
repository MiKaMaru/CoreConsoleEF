using Microsoft.EntityFrameworkCore;

namespace CoreConsoleEF
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeUser> HomeUsers { get; set; }


        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeUser>().HasKey(sc => new { sc.UserId, sc.HomeId });
        }
    }
}
