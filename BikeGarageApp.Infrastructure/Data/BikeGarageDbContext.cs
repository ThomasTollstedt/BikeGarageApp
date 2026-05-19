using BikeGarageApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeGarageApp.Infrastructure.Data
{
    public class BikeGarageDbContext : DbContext
    {
        public BikeGarageDbContext(DbContextOptions<BikeGarageDbContext> options)
            : base(options)
        { }
        
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            
            modelBuilder.Entity<Bike>()
                .Property(b => b.Milage)
                .HasPrecision(18, 2);
        }
    }
}
