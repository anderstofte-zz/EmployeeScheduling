using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduling.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduling.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeSchedulingContext _context;

        public EmployeeRepository(EmployeeSchedulingContext context)
        {
            _context = context;
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _context.Employees.Where(e => e.EmployeeId == employeeId).SingleOrDefaultAsync();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await _context.Employees.Where(x => x.Email == email).SingleOrDefaultAsync();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
