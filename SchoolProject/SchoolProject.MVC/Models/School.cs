using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class School {
        public int SchoolId { get; set; }

        [Required]
        public string? SchoolName { get; set; }
    }
}