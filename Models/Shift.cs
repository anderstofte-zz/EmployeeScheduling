using System;

namespace EmployeeScheduling.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
    }
}