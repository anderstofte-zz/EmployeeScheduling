using EmployeeScheduling.Models;
using EmployeeScheduling.ViewModels;

namespace EmployeeScheduling.Converters
{
    public static class EmployeeConverter
    {
        public static Employee ToEmployee(this EmployeeModel model)
        {
            return new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };
        }

        public static EmployeeModel ToModel(this Employee employee)
        {
            return new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FullName = $"{employee.FirstName} {employee.LastName}",
                Email = employee.Email
            };
        }
    }
}
