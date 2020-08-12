using System.Threading.Tasks;
using EmployeeScheduling.Models;

namespace EmployeeScheduling.Data.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Task<Employee> GetById(int employeeId);
        Task<Employee> GetByEmail(string email);
        void  Delete(Employee employee);
        Task SaveChanges();
    }
}