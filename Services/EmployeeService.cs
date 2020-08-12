using System.Threading.Tasks;
using EmployeeScheduling.Converters;
using EmployeeScheduling.Data.Repositories;
using EmployeeScheduling.Extensions;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> CreateEmployee(EmployeeModel model)
        {
            if (await IsEmailInUse(model.Email))
            {
                return new BadRequestObjectResult("Email is already in use.");
            }

            var employee = model.ToEmployee();
            _employeeRepository.Create(employee);
            await _employeeRepository.SaveChanges();

            return new OkResult();
        }

        private async Task<bool> IsEmailInUse(string email)
        {
            var employee = await _employeeRepository.GetByEmail(email);
            return employee != null;
        }

        public async Task<IActionResult> UpdateEmployee(int employeeId, EmployeeModel model)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                return new NotFoundResult();
            }
            
            if (await IsEmailInUse(model.Email) && employee.Email != model.Email)
            {
                return new BadRequestObjectResult("Email is already in use.");
            }

            employee.Update(model);
            await _employeeRepository.SaveChanges();

            return new OkResult();
        }

        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                return new NotFoundResult();
            }

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveChanges();

            return new OkResult();
        }
    }
}
