using EmployeeScheduling.ViewModels;
using FluentValidation;

namespace EmployeeScheduling.Validations
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        private const string EmailRegex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                          + "@"
                                          + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
        public EmployeeModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).Matches(EmailRegex).WithMessage("The email is invalid.");
        }
    }
}