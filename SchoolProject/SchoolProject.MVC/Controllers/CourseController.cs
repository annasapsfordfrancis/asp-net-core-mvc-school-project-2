using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        public CourseController(SchoolProjectDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            if (_context.Course == null)
            {
                return NotFound();
            }
            var model = await _context.Course.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("CourseName","CourseDescription")] Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}