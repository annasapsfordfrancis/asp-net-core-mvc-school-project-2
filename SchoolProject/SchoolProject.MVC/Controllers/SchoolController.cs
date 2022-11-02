using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class SchoolController : Controller
    {
        private readonly SchoolProjectDbContext _context;
        private IValidator<School> _validator;
        public SchoolController(SchoolProjectDbContext context, IValidator<School> validator)
        {
            _context = context;
            _validator = validator;
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
        public async Task<IActionResult> Create(School school)
        {
            ValidationResult result = await _validator.ValidateAsync(school);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create", school);
            }
            _context.Add(school);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.School
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var school = await _context.School.FindAsync(id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}