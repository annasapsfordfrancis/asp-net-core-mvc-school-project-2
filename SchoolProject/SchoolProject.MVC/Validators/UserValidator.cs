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
        }
    }
}