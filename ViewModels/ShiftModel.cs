using System;

namespace EmployeeScheduling.ViewModels
{
    public class ShiftModel
    {
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
    }
}