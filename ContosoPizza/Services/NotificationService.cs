using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class NotificationService
    {
        private readonly ContosoPizzaDbContext _context;

        public NotificationService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync() =>
            await _context.Notifications.ToListAsync();

        public async Task<Notification?> GetByIdAsync(string id) =>
            await _context.Notifications.FindAsync(id);

        public async Task<Notification> CreateAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<bool> MarkAsReadAsync(string id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification is null) return false;

            notification.IsRead = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification is null) return false;

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
