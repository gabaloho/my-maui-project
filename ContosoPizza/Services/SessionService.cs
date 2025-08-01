using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class SessionService
    {
        private readonly ContosoPizzaDbContext _context;

        public SessionService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Session>> GetAllAsync() =>
            await _context.Sessions.ToListAsync();

        public async Task<Session?> GetByTokenAsync(string token) =>
            await _context.Sessions.FirstOrDefaultAsync(s => s.Token == token);

        public async Task<Session> CreateAsync(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<bool> DeleteAsync(string token)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Token == token);
            if (session is null) return false;

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
