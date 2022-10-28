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
        private IValidator<User> _validator;
        public UserController(SchoolProjectDbContext context, IValidator<User> validator)
        {
            _context = context;
            _validator = validator;
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
            var viewModel = new AddUserViewModel {
                User = new User { },
                SchoolList = _context.School.ToList(),
                UserTypeList = _context.UserType.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserTypeId","FirstName", "LastName", "YearGroup", "SchoolId")] User user)
        {
            ValidationResult result = await _validator.ValidateAsync(user);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
