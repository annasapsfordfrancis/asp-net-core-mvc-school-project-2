using SchoolProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel BuildUserViewModel(UserViewModel viewModel = null);
        Task<ActionResult> AddUser(User user);
        Task<ActionResult> EditUser(User user);
        Task<ActionResult> DeleteUser(int id);
        Task<User> GetUser(int id);
        Task<List<User>> GetUsers();
        Task<UserViewModel> GetUserViewModel(int id);
    }
}
