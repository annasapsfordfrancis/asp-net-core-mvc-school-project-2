using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class UserType {
        public int UserTypeId { get; set; }

        [Display(Name = "User Type")]
        public string? UserTypeName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}