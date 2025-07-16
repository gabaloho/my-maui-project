// EmployeeService.cs
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class EmployeeService
    {
        private readonly ContosoPizzaDbContext _context;

        public EmployeeService(ContosoPizzaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync() =>
            await _context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(string id) =>
            await _context.Employees.FindAsync(id);

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(string id, Employee updated)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null) return false;

            employee.FullName = updated.FullName;
            employee.Role = updated.Role;
            employee.Email = updated.Email;
            employee.StoreId = updated.StoreId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee is null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
