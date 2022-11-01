using FluentValidation;
using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(course => course.CourseName).NotNull().WithMessage("Please enter a course name");
            RuleFor(course => course.CourseDescription).NotNull().WithMessage("Please enter a course description");
        }
    }
}
