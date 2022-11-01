using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class SchoolValidator : AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(school => school.SchoolName).NotNull().WithMessage("Please enter a school name");
        }
    }

}