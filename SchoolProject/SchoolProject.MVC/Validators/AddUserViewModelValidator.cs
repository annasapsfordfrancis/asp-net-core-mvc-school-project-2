using FluentValidation;

using SchoolProject.Models;

namespace SchoolProject.Validators
{
    public class AddUserViewModelValidator: AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidator()
        {
            RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }
}