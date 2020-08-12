using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeScheduling.Models;

namespace EmployeeScheduling.Data.Repositories
{
    public interface IShiftRepository
    {
        void CreateShift(Shift shift);
        Task<List<Shift>> GetAllShifts();
        Task<List<Shift>> GetShiftsFromEmployee(int employeeId);
        Task<Shift> GetShift(int shiftId);
        Task UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
        Task SaveChanges();
        Task<bool> IsEmployeeAlreadyAssignedAShift(Shift shift, int employeeId);
    }
}
