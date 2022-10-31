using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().WithMessage("Please enter the user's first name");
            RuleFor(user => user.LastName).NotNull().WithMessage("Please enter the user's last name");
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Please enter the user's first name");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Please enter the user's last name");
            RuleFor(user => user.SchoolId).NotEqual(0).WithMessage("Please enter the user's school");
            RuleFor(user => user.UserTypeId).NotEqual(0).WithMessage("Please enter the user's type");
        }
    }
}