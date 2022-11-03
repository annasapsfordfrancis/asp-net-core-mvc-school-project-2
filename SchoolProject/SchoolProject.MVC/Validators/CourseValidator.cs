using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(course => course.CourseName)
                .NotNull().WithMessage("Please enter a course name")
                .NotEmpty().WithMessage("Please enter a course name")
                .MinimumLength(3).WithMessage("The course name must have at least 3 characters")
                .MaximumLength(30).WithMessage("The course name mustn't have more than 30 characters");

            RuleFor(course => course.CourseDescription)
                .NotNull().WithMessage("Please enter a course description")
                .NotEmpty().WithMessage("Please enter a course description")
                .MinimumLength(3).WithMessage("The course description must have at least 3 characters");
        }
    }
}
