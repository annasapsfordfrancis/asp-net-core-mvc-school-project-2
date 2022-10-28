using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class User {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = String.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = String.Empty;

        [Display(Name = "Year Group")]
        public int? YearGroup { get; set; }
        public DateTime? DateOfBirth { get; set; } = new DateTime();
        public int SchoolId { get; set; }
        public UserType? UserType { get; set; }
        public School? School { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}