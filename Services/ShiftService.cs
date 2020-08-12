using System.Threading.Tasks;
using EmployeeScheduling.Converters;
using EmployeeScheduling.Data.Repositories;
using EmployeeScheduling.Extensions;
using EmployeeScheduling.Models;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository, IEmployeeRepository employeeRepository)
        {
            _shiftRepository = shiftRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> CreateShift(ShiftModel model)
        {
            if (!await EmployeeExists(model.EmployeeId))
            {
                return new NotFoundResult();
            }

            var shift = model.ToShift();
            if (await _shiftRepository.IsEmployeeAlreadyAssignedAShift(shift, model.EmployeeId))
            {
                return new BadRequestObjectResult("A shift is already assigned to the employee.");
            }

            _shiftRepository.CreateShift(shift);
            await _shiftRepository.SaveChanges();

            return new OkResult();
        }

        public async Task<IActionResult> UpdateShift(int shiftId, ShiftModel model)
        {
            var shift = await _shiftRepository.GetShift(shiftId);
            if (shift == null)
            {
                return new NotFoundResult();
            }

            shift.Update(model);
            if (await _shiftRepository.IsEmployeeAlreadyAssignedAShift(shift, shift.EmployeeId))
            {
                return new BadRequestObjectResult("A shift is already assigned to the employee.");
            }

            await _shiftRepository.SaveChanges();

            return new OkResult();
        }

        public async Task<IActionResult> SwapShifts(SwapShiftsModel model)
        {
            var shiftOne = await _shiftRepository.GetShift(model.FirstShiftId);
            var shiftTwo = await _shiftRepository.GetShift(model.SecondShiftId);
            if (shiftOne == null || shiftTwo == null)
            {
                return new BadRequestObjectResult("One or more shifts could not be found with the supplied ID's.");
            }

            if (DoesTheShiftsBelongToTheSameEmployee(shiftOne, shiftTwo))
            {
                return new BadRequestObjectResult("The shifts can not be swapped since they belong to the same employee.");
            }

            if (await CanEmployeesSwapShifts(shiftOne, shiftTwo))
            {
                return new BadRequestObjectResult("One or more employees are not able to swap shift.");
            }

            var temp = shiftOne.EmployeeId;
            shiftOne.EmployeeId = shiftTwo.EmployeeId;
            shiftTwo.EmployeeId = temp;

            await _shiftRepository.SaveChanges();

            return new OkObjectResult("The shifts has been swapped.");
        }

        public async Task<IActionResult> DeleteShift(int shiftId)
        {
            var shift = await _shiftRepository.GetShift(shiftId);
            if (shift == null)
            {
                return new NotFoundResult();
            }

            _shiftRepository.DeleteShift(shift);
            await _shiftRepository.SaveChanges();

            return new OkResult();
        }

        private async Task<bool> EmployeeExists(int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            return employee != null;
        }

        private static bool DoesTheShiftsBelongToTheSameEmployee(Shift shiftOne, Shift shiftTwo)
        {
            return shiftOne.EmployeeId == shiftTwo.EmployeeId;
        }

        private async Task<bool> CanEmployeesSwapShifts(Shift shiftOne, Shift shiftTwo)
        {
            return await _shiftRepository.IsEmployeeAlreadyAssignedAShift(shiftOne, shiftOne.EmployeeId) && 
                   await _shiftRepository.IsEmployeeAlreadyAssignedAShift(shiftTwo, shiftTwo.EmployeeId);
        }
    }
}
