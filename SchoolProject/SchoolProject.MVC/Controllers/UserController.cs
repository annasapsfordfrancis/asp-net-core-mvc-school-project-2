using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class UserController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        public UserController(SchoolProjectDbContext context)
        {
            _context = context;
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
            if(ModelState.IsValid) {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            } else {
                return View();
            }
            
        }
    }
}
