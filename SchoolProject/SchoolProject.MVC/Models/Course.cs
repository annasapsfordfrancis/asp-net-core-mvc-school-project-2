using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Course {
        public int CourseId { get; set; }

        [Required]
        public string? CourseName { get; set; }

        [Required]
        public string? CourseDescription { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}