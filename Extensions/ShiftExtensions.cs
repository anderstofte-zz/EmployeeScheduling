using EmployeeScheduling.Models;
using EmployeeScheduling.ViewModels;

namespace EmployeeScheduling.Extensions
{
    public static class ShiftExtensions
    {
        public static void Update(this Shift shift, ShiftModel model)
        {
            shift.ShiftStart = model.ShiftStart;
            shift.ShiftEnd = model.ShiftEnd;
        }
    }
}