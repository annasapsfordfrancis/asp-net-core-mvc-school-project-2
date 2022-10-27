using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        public SchoolController(SchoolProjectDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            if (_context.School == null)
            {
                return NotFound();
            }
            var model = await _context.School.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("SchoolName")] School school)
        {
            _context.Add(school);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}