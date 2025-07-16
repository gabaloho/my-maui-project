using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContosoPizza.Services
{
    public class ContosoPizzaDbContext : DbContext
    {
        public ContosoPizzaDbContext(DbContextOptions<ContosoPizzaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stores> Stores { get; set; } = null!;
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<DeliveryZone> DeliveryZones { get; set; } = null!;
        public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
        public DbSet<StoreReview> StoreReviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stores>().ToCollection("stores");
            modelBuilder.Entity<Customer>().ToCollection("customers");
            modelBuilder.Entity<DeliveryZone>().ToCollection("deliveryzones");
            modelBuilder.Entity<Employee>().ToCollection("employees");
            modelBuilder.Entity<InventoryItem>().ToCollection("inventoryitems");
            modelBuilder.Entity<Order>().ToCollection("orders");
            modelBuilder.Entity<Pizza>().ToCollection("pizzas");
            modelBuilder.Entity<StoreReview>().ToCollection("reviews");
        }
    }
}
