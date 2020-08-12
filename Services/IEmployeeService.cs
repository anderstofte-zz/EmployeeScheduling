using System.Threading.Tasks;
using EmployeeScheduling.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeScheduling.Services
{
    public interface IEmployeeService
    {
        Task<IActionResult> CreateEmployee(EmployeeModel model);
        Task<IActionResult> UpdateEmployee(int employeeId, EmployeeModel model);
        Task<IActionResult> DeleteEmployee(int employeeId);
    }
}