using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class StoreReviewService
    {
        private readonly ContosoPizzaDbContext _context;

        public StoreReviewService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<StoreReview>> GetAllAsync()
        {
            return await _context.StoreReviews.ToListAsync();
        }

        public async Task<List<StoreReview>> GetByStoreIdAsync(string storeId)
        {
            return await _context.StoreReviews
                .Where(r => r.StoreId == storeId)
                .ToListAsync();
        }

        public async Task<StoreReview?> GetByIdAsync(string id)
        {
            return await _context.StoreReviews.FindAsync(id);
        }

        public async Task<StoreReview> CreateAsync(StoreReview review)
        {
            _context.StoreReviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> UpdateAsync(string id, StoreReview review)
        {
            var existing = await _context.StoreReviews.FindAsync(id);
            if (existing == null) return false;

            existing.CustomerId = review.CustomerId;
            existing.StoreId = review.StoreId;
            existing.Rating = review.Rating;
            existing.Comment = review.Comment;
            existing.ReviewDate = review.ReviewDate;

            _context.StoreReviews.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var existing = await _context.StoreReviews.FindAsync(id);
            if (existing == null) return false;

            _context.StoreReviews.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
