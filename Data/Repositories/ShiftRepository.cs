using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduling.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeScheduling.Data.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly EmployeeSchedulingContext _context;

        public ShiftRepository(EmployeeSchedulingContext context)
        {
            _context = context;
        }

        public void CreateShift(Shift shift)
        {
            _context.Add(shift);
        }

        public Task<List<Shift>> GetAllShifts()
        {
            return _context.Shifts.ToListAsync();
        }

        public async Task<List<Shift>> GetShiftsFromEmployee(int employeeId)
        {
            return await _context.Shifts.Where(s => s.EmployeeId == employeeId).ToListAsync();
        }

        public Task<Shift> GetShift(int shiftId)
        {
            return _context.Shifts.Where(x => x.ShiftId == shiftId).SingleOrDefaultAsync();
        }

        public async Task UpdateShift(Shift shift)
        {
            _context.Entry(shift).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void DeleteShift(Shift shift)
        {
            _context.Shifts.Remove(shift);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmployeeAlreadyAssignedAShift(Shift shift, int employeeId)
        {
            return await _context.Shifts
                .Where(x => x.EmployeeId == employeeId)
                .Where(x => x.ShiftId != shift.ShiftId)
                .AnyAsync(x => x.ShiftStart <= shift.ShiftEnd &&
                               x.ShiftEnd >= shift.ShiftStart);
        }
    }
}
