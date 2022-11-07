using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class UserListViewModel
    {
        public int? SelectedUserTypeId { get; set; }
        public int? SelectedSchoolId { get; set; }

        [Display(Name = "School")]
        public List<School> SchoolList { get; set; }

        [Display(Name = "User Type")]
        public List<UserType> UserTypeList { get; set; }
        public List<User> UserResults { get; set; }
    }
}
