using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class School {
        public int SchoolId { get; set; }

        [Display(Name = "School Name")]
        public string? SchoolName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}