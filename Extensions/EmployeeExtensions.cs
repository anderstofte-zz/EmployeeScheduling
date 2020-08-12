using EmployeeScheduling.Models;
using EmployeeScheduling.ViewModels;

namespace EmployeeScheduling.Extensions
{
    public static class EmployeeExtensions
    {
        public static void Update(this Employee employee, EmployeeModel model)
        {
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
        }
    }
}
