using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class SchoolValidator : AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(school => school.SchoolName)
                .NotNull().WithMessage("Please enter a school name")
                .NotEmpty().WithMessage("Please enter a school name")
                .MinimumLength(3).WithMessage("The school name must have at least 3 characters")
                .MaximumLength(30).WithMessage("The school name mustn't have more than 30 characters");
        }
    }

}