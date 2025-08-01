using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class AuditLogService
    {
        private readonly ContosoPizzaDbContext _context;

        public AuditLogService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuditLog>> GetAllAsync() =>
            await _context.AuditLogs.ToListAsync();

        public async Task<AuditLog?> GetByIdAsync(string id) =>
            await _context.AuditLogs.FindAsync(id);

        public async Task<AuditLog> CreateAsync(AuditLog log)
        {
            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }
    }
}
