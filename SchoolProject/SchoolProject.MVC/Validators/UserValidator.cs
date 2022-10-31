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
            RuleFor(user => user.SchoolId).NotNull().WithMessage("Please enter the user's school");
            RuleFor(user => user.UserTypeId).NotNull().WithMessage("Please enter the user's type");

            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Please enter the user's first name");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Please enter the user's last name");
            RuleFor(user => user.SchoolId).NotEmpty().WithMessage("Please enter the user's school");
            RuleFor(user => user.UserTypeId).NotEmpty().WithMessage("Please enter the user's type");
        }
    }
}