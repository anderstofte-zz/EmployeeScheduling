using EmployeeScheduling.Models;
using EmployeeScheduling.ViewModels;

namespace EmployeeScheduling.Converters
{
    public static class ShiftConverter
    {
        public static Shift ToShift(this ShiftModel model)
        {
            return new Shift
            {
                ShiftId = model.ShiftId,
                EmployeeId = model.EmployeeId,
                ShiftStart = model.ShiftStart,
                ShiftEnd = model.ShiftEnd
            };
        }
    }
}