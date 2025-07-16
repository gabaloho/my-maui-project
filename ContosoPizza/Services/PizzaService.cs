using System.Security.Cryptography.X509Certificates;
using MongoDB.Bson;
using MongoDB.Driver;
using ContosoPizza.Services;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{

    public class PizzaService
    {
        private readonly ContosoPizzaDbContext _context;

        public PizzaService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pizza>> GetAllAsync() =>
            await _context.Pizzas.ToListAsync();

        public async Task<Pizza?> GetByIdAsync(string id) =>
            await _context.Pizzas.FindAsync(id);

        public async Task AddAsync(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pizza pizza)
        {
            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var pizza = await GetByIdAsync(id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
            }
        }
    }
}

