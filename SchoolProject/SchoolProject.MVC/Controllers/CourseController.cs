using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        private IValidator<Course> _validator;
        public CourseController(SchoolProjectDbContext context, IValidator<Course> validator)
        {
            _context = context;
            _validator = validator;
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
            ValidationResult result = await _validator.ValidateAsync(course);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create", course);
            }
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}