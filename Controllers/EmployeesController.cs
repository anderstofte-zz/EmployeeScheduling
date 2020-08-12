using System.Threading.Tasks;
using EmployeeScheduling.Converters;
using EmployeeScheduling.Data.Repositories;
using EmployeeScheduling.Services;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeModel model)
        {
            return await _employeeService.CreateEmployee(model);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.ToModel());
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, EmployeeModel model)
        {
            return await _employeeService.UpdateEmployee(employeeId, model);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            return await _employeeService.DeleteEmployee(employeeId);
        }
    }
}
