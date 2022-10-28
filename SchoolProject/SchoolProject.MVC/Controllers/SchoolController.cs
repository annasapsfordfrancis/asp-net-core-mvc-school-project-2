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
        public async Task<IActionResult> Create([Bind("SchoolName")] School school)
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
    }
}