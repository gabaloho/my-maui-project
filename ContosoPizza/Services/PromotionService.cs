using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class PromotionService
    {
        private readonly ContosoPizzaDbContext _context;

        public PromotionService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Promotion>> GetAllAsync() =>
            await _context.Promotions.ToListAsync();

        public async Task<Promotion?> GetByIdAsync(string id) =>
            await _context.Promotions.FindAsync(id);

        public async Task<Promotion> CreateAsync(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
            return promotion;
        }

        public async Task<bool> UpdateAsync(string id, Promotion updated)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo is null) return false;

            promo.Code = updated.Code;
            promo.Description = updated.Description;
            promo.DiscountPercent = updated.DiscountPercent;
            promo.DiscountAmount = updated.DiscountAmount;
            promo.ValidFrom = updated.ValidFrom;
            promo.ValidTo = updated.ValidTo;
            promo.ApplicableStoreIds = updated.ApplicableStoreIds;
            promo.IsActive = updated.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo is null) return false;

            _context.Promotions.Remove(promo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
