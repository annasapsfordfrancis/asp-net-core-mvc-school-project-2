using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.MVC.Controllers
{
    public class UserController : Controller
    {
        private IValidator<UserViewModel> _UserViewModelValidator;
        private IUserService _userService;
        public UserController(IValidator<UserViewModel> UserViewModelValidator, IUserService userService)
        {
            _UserViewModelValidator = UserViewModelValidator;
            _userService = userService;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();

            return View(users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = _userService.BuildUserViewModel();

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)
        {
            ValidationResult result = await _UserViewModelValidator.ValidateAsync(viewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                viewModel = _userService.BuildUserViewModel(viewModel);
                return View(viewModel);
            }
            await _userService.AddUser(viewModel.User);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _userService.GetUserViewModel(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _userService.GetUserViewModel(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            ValidationResult result = await _UserViewModelValidator.ValidateAsync(viewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                viewModel = _userService.BuildUserViewModel(viewModel);
                return View(viewModel);
            }
            await _userService.EditUser(viewModel.User);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await _userService.GetUserViewModel(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
