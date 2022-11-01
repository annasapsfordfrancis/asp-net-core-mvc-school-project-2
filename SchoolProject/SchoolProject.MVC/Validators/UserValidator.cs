using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotNull().WithMessage("Please enter a first name")
                .NotEmpty().WithMessage("Please enter a first name");
            RuleFor(user => user.LastName)
                .NotNull().WithMessage("Please enter a last name")
                .NotEmpty().WithMessage("Please enter a last name");

            RuleFor(user => user.SchoolId).NotEqual(0).WithMessage("Please enter a school");
            RuleFor(user => user.UserTypeId).NotEqual(0).WithMessage("Please enter a user type");
        }
    }
}