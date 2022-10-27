namespace SchoolProject.Models
{
    public class Course {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}