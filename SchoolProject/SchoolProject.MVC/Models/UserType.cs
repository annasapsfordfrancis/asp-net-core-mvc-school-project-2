using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class UserType {
        public int UserTypeId { get; set; }

        [Required]
        public string? UserTypeName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}