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

        public DbSet<Contoso> Contosos { get; set; } = null!;
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contoso>()
                .ToCollection("contosos");
            modelBuilder.Entity<Pizza>()
                .ToCollection("pizzas");
            modelBuilder.Entity<OrderItem>()
                .ToCollection("orderitems");
            modelBuilder.Entity<Order>()
                .ToCollection("orders");
            modelBuilder.Entity<Customer>()
                .ToCollection("customers");
        }
    }
}