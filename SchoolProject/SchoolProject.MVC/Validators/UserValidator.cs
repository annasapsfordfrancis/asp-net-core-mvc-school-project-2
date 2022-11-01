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
                .NotEmpty().WithMessage("Please enter a first name")
                .MinimumLength(3).WithMessage("The first name must have at least 3 characters")
                .MaximumLength(20).WithMessage("The first name mustn't have more than 20 characters");
            RuleFor(user => user.LastName)
                .NotNull().WithMessage("Please enter a last name")
                .NotEmpty().WithMessage("Please enter a last name")
                .MinimumLength(3).WithMessage("The last name must have at least 3 characters")
                .MaximumLength(30).WithMessage("The last name mustn't have more than 30 characters");

            RuleFor(user => user.SchoolId).NotEqual(0).WithMessage("Please enter a school");
            RuleFor(user => user.UserTypeId).NotEqual(0).WithMessage("Please enter a user type");
        }
    }
}