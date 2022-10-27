using SchoolProject.Models;

namespace SchoolProject.MVC.Models
{
    public class AddUserViewModel
    {

        public User User { get; set; }
        public List<School> SchoolList { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}
