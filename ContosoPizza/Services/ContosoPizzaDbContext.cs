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

        // Newly added models
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Promotion> Promotions { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

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
            modelBuilder.Entity<StoreReview>().ToCollection("storereviews");

            // Newly added models
            modelBuilder.Entity<Payment>().ToCollection("payments");
            modelBuilder.Entity<Promotion>().ToCollection("promotions");
            modelBuilder.Entity<Ingredient>().ToCollection("ingredients");
            modelBuilder.Entity<AuditLog>().ToCollection("auditlogs");
            modelBuilder.Entity<Session>().ToCollection("sessions");
            modelBuilder.Entity<Notification>().ToCollection("notifications");
        }
    }
}
