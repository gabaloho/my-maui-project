using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class DeliveryZoneService
    {
        private readonly ContosoPizzaDbContext _context;

        public DeliveryZoneService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeliveryZone>> GetAllAsync()
        {
            return await _context.DeliveryZones.ToListAsync();
        }

        public async Task<DeliveryZone?> GetByIdAsync(string id)
        {
            return await _context.DeliveryZones
                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<DeliveryZone> CreateAsync(DeliveryZone zone)
        {
            _context.DeliveryZones.Add(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        public async Task<bool> UpdateAsync(string id, DeliveryZone updatedZone)
        {
            var existing = await _context.DeliveryZones.FirstOrDefaultAsync(z => z.Id == id);
            if (existing == null) return false;

            existing.Name = updatedZone.Name;
            existing.Area = updatedZone.Area;
            existing.StoreIds = updatedZone.StoreIds;
            existing.DeliveryFee = updatedZone.DeliveryFee;
            existing.MinimumOrderAmount = updatedZone.MinimumOrderAmount;
            existing.DeliveryTimeSlots = updatedZone.DeliveryTimeSlots;

            _context.DeliveryZones.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _context.DeliveryZones.FirstOrDefaultAsync(z => z.Id == id);
            if (existing == null) return false;

            _context.DeliveryZones.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
