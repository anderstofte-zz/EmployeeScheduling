using EmployeeScheduling.ViewModels;
using FluentValidation;

namespace EmployeeScheduling.Validations
{
    public class ShiftModelValidator : AbstractValidator<ShiftModel>
    {
        public ShiftModelValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty();
            RuleFor(x => x.ShiftStart).NotEmpty();
            RuleFor(x => x.ShiftEnd).NotEmpty();
            RuleFor(x => x.ShiftStart).LessThan(x => x.ShiftEnd).WithMessage("Invalid shift: ShiftEnd is before ShiftStart.");
        }
    }
}
