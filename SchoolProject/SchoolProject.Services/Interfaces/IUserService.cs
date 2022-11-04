using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Interfaces
{
    public interface IUserService
    {
        AddUserViewModel BuildAddUserViewModel(AddUserViewModel viewModel = null);
    }
}
