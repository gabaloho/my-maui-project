using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class InventoryItemService
    {
        private readonly ContosoPizzaDbContext _context;

        public InventoryItemService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryItem>> GetAllAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem?> GetByIdAsync(string id)
        {
            return await _context.InventoryItems.FindAsync(id);
        }

        public async Task<List<InventoryItem>> GetByStoreIdAsync(string storeId)
        {
            return await _context.InventoryItems
                .Where(item => item.StoreId == storeId)
                .ToListAsync();
        }

        public async Task AddAsync(InventoryItem item)
        {
            await _context.InventoryItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
