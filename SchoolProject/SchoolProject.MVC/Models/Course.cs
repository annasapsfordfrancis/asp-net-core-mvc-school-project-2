using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Course {
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string? CourseName { get; set; }

        [Display(Name = "Course Description")]
        public string? CourseDescription { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}