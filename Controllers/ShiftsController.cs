using System.Threading.Tasks;
using EmployeeScheduling.Data.Repositories;
using EmployeeScheduling.Services;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly IShiftRepository _shiftRepository;

        public ShiftsController(IShiftService shiftService, IShiftRepository shiftRepository)
        {
            _shiftService = shiftService;
            _shiftRepository = shiftRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(ShiftModel model)
        {
            return await _shiftService.CreateShift(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetShiftsFromEveryEmployee()
        {
            var shifts = await _shiftRepository.GetAllShifts();
            return Ok(shifts);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetShiftsByEmployeeId(int employeeId)
        {
            var shifts = await _shiftRepository.GetShiftsFromEmployee(employeeId);
            if (shifts == null)
            {
                return NotFound("The employee does not exist or has not any shifts.");
            }

            return Ok(shifts);
        }

        [HttpPut("{shiftId}")]
        public async Task<IActionResult> UpdateShift(int shiftId, ShiftModel model)
        {
            return await _shiftService.UpdateShift(shiftId, model);
        }

        [HttpPut("swap")]
        public async Task<IActionResult> SwapShifts(SwapShiftsModel model)
        {
            return await _shiftService.SwapShifts(model);
        }

        [HttpDelete("{shiftId}")]
        public async Task<IActionResult> DeleteShift(int shiftId)
        {
            return await _shiftService.DeleteShift(shiftId);
        }
    }
}
