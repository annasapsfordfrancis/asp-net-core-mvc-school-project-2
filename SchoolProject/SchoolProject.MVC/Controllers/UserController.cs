using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;
using SchoolProject.Data;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        private IValidator<AddUserViewModel> _addUserViewModelValidator;
        private IUserService _userService;
        public UserController(SchoolProjectDbContext context, IValidator<AddUserViewModel> addUserViewModelValidator, IUserService userService)
        {
            _context = context;
            _addUserViewModelValidator = addUserViewModelValidator;
            _userService = userService;
        }


        public async Task<IActionResult> Index()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var model = await _context.User.Include(m => m.School).Include(m => m.UserType).ToListAsync();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = _userService.BuildAddUserViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUserViewModel viewModel)
        {
            ValidationResult result = await _addUserViewModelValidator.ValidateAsync(viewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                viewModel = _userService.BuildAddUserViewModel(viewModel);
                return View(viewModel);
            }
            var user = viewModel.User;
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = _userService.BuildAddUserViewModel();
            viewModel.User = user;

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = _userService.BuildAddUserViewModel();
            viewModel.User = user;

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddUserViewModel viewModel)
        {
            ValidationResult result = await _addUserViewModelValidator.ValidateAsync(viewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                viewModel = _userService.BuildAddUserViewModel(viewModel);
                return View(viewModel);
            }
            _context.Update(viewModel.User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = _userService.BuildAddUserViewModel();
            viewModel.User = user;

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
