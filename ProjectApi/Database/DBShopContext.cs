using Microsoft.EntityFrameworkCore;
using ProjectApi.Entities;

namespace ProjectApi.Database
{
    public class DBShopContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DJFJHDI;Database=shopDatabase;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}