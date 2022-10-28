using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class AddUserViewModel
    {

        public User User { get; set; }

        [Display(Name = "School")]
        public List<School> SchoolList { get; set; }

        [Display(Name = "User Type")]
        public List<UserType> UserTypeList { get; set; }
    }
}
