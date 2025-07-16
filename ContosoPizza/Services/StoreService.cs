using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class StoreService
    {
        private readonly ContosoPizzaDbContext _context;

        public StoreService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stores>> GetAllAsync() =>
            await _context.Stores.ToListAsync();

        public async Task<Stores?> GetByIdAsync(string id) =>
            await _context.Stores.FindAsync(id);

        public async Task AddAsync(Stores store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stores store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var store = await GetByIdAsync(id);
            if (store != null)
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }
    }
}
