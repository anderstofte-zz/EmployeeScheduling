using System.Collections.Generic;

namespace EmployeeScheduling.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Shift> Shifts { get; set; }

        public Employee()
        {
            Shifts = new List<Shift>();
        }
    }
}