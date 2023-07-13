using Lesson7.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson7.EfCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Driver)
                .WithOne(d => d.Car)
                .HasForeignKey<Driver>(d => d.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
