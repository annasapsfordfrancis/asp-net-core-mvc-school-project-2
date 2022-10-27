namespace SchoolProject.Models
{
    public class School {
        public int SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}