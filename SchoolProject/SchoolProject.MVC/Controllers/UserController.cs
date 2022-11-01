using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class UserController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        private IValidator<AddUserViewModel> _addUserViewModelValidator;
        public UserController(SchoolProjectDbContext context, IValidator<AddUserViewModel> addUserViewModelValidator)
        {
            _context = context;
            _addUserViewModelValidator = addUserViewModelValidator;
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
            var viewModel = BuildAddUserViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUserViewModel viewModel)
        {
            ValidationResult result = await _addUserViewModelValidator.ValidateAsync(viewModel);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                viewModel = BuildAddUserViewModel(viewModel);
                return View(viewModel);
            }
            var user = viewModel.User;
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
