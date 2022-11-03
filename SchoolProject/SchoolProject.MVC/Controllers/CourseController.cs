using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;
using SchoolProject.Data;

namespace SchoolProject.MVC.Controllers
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
        public async Task<IActionResult> Create(Course course)
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            ValidationResult result = await _validator.ValidateAsync(course);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(course);
            }
            _context.Update(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}