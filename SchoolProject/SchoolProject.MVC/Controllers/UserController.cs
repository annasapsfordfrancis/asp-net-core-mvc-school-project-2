using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.MVC.Models;

namespace SchoolProject.MVC.Controllers
{


 

    public class UserController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        public UserController(SchoolProjectDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new AddUserViewModel {
                User = new User { },
                SchoolList = _context.School.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            return View("Index");
        }
    }
}
