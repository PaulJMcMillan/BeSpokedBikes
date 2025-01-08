using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repositories
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<SalesListViewModel> SalesList { get; set; }
        public DbSet<CommissionReportViewModel> CommissionReport { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesListViewModel>().HasNoKey(); // Since this is not tracked as an entity
            modelBuilder.Entity<CommissionReportViewModel>().HasNoKey(); 
        }
    }
}
