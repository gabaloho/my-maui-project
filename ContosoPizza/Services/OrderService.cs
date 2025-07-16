// OrderService.cs
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class OrderService
    {
        private readonly ContosoPizzaDbContext _context;

        public OrderService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync() =>
            await _context.Orders.Include(o => o.Items).ToListAsync();

        public async Task<Order?> GetByIdAsync(string id) =>
            await _context.Orders.Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}