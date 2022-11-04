using FluentValidation;

using SchoolProject.Models;

namespace SchoolProject.Services.Validators
{
    public class UserViewModelValidator: AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }
}