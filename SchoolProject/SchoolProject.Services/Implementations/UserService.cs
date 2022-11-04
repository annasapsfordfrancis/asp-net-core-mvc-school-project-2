using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementations
{




    public class UserService : IUserService
    {
        private readonly SchoolProjectDbContext _context;
        public UserService(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public AddUserViewModel BuildAddUserViewModel(AddUserViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new AddUserViewModel
                {
                    User = new User { },
                };
            }

            viewModel.SchoolList = _context.School.ToList();
            viewModel.UserTypeList = _context.UserType.ToList();

            return viewModel;
        }
    }
}
