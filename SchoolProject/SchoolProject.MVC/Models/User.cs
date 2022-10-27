namespace SchoolProject.Models
{
    public class User {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int? YearGroup { get; set; }
        public DateTime? DateOfBirth { get; set; } = new DateTime();
        public int SchoolId { get; set; }
        public UserType? UserType { get; set; }
        public School? School { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}