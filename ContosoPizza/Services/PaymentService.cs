using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class PaymentService
    {
        private readonly ContosoPizzaDbContext _context;

        public PaymentService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllAsync() =>
            await _context.Payments.ToListAsync();

        public async Task<Payment?> GetByIdAsync(string id) =>
            await _context.Payments.FindAsync(id);

        public async Task<Payment> CreateAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> UpdateAsync(string id, Payment updated)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment is null) return false;

            // Update fields as needed
            payment.Status = updated.Status;
            payment.RefundAmount = updated.RefundAmount;
            payment.RefundDate = updated.RefundDate;
            payment.RefundStatus = updated.RefundStatus;
            payment.Notes = updated.Notes;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment is null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
