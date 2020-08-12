using System.Threading.Tasks;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Services
{
    public interface IShiftService
    {
        Task<IActionResult> CreateShift(ShiftModel model);
        Task<IActionResult> UpdateShift(int shiftId, ShiftModel model);
        Task<IActionResult> SwapShifts(SwapShiftsModel model);
        Task<IActionResult> DeleteShift(int shiftId);
    }
}