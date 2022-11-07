using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly SchoolProjectDbContext _context;
        public UserService(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public UserViewModel BuildUserViewModel(UserViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new UserViewModel
                {
                    User = new User { },
                };
            }

            viewModel.SchoolList = _context.School.ToList();
            viewModel.UserTypeList = _context.UserType.ToList();

            return viewModel;
        }

        public async Task<ActionResult> AddUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> EditUser(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await GetUser(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.User.Include(m => m.School).Include(m => m.UserType).ToListAsync();

            return users;
        }

        public async Task<UserViewModel> GetUserViewModel(int id)
        {
            var user = await GetUser(id);

            var viewModel = new UserViewModel();
            viewModel = BuildUserViewModel();
            viewModel.User = user;

            return viewModel;
        }

        public async Task<UserListViewModel> GetUserListViewModel(UserListViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new UserListViewModel();
            }

            viewModel.SchoolList = await _context.School.ToListAsync();
            viewModel.UserTypeList = await _context.UserType.ToListAsync();

            var filteredUserList = await GetFilteredUsers(viewModel.SelectedSchoolId, viewModel.SelectedUserTypeId);

            viewModel.UserResults = filteredUserList;

            return viewModel;
        }

        private async Task<List<User>> GetFilteredUsers(int? schoolId, int? userTypeId)
        {
            var filteredUserList = new List<User>();

            bool schoolIdIsSet = (schoolId != 0 && schoolId != null) ? true : false;
            bool userTypeIdIsSet = (userTypeId != 0 && userTypeId != null) ? true : false;

            // Only schoolId is set
            if(schoolIdIsSet && !userTypeIdIsSet)
            {
                filteredUserList.AddRange(await _context.User.Where(a => a.SchoolId == schoolId).Include(a => a.School).Include(a => a.UserType).ToListAsync());
            }

            // Only userTypeId is set
            else if (userTypeIdIsSet && !schoolIdIsSet)
            {
                filteredUserList.AddRange(await _context.User.Where(a => a.UserTypeId == userTypeId).Include(a => a.School).Include(a => a.UserType).ToListAsync());
            }

            // Both schoolId and userTypeId are set
            else if (schoolIdIsSet && userTypeIdIsSet)
            {
                filteredUserList.AddRange(await _context.User.Where(a => a.SchoolId == schoolId).Where(a => a.UserTypeId == userTypeId).Include(a => a.School).Include(a => a.UserType).ToListAsync());
            }

            // No filter is set -> return all users
            else
            {
                filteredUserList = await GetUsers();
            }

            return filteredUserList;
        }
    }
}
