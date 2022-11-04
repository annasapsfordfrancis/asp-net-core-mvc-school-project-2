using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.MVC.Controllers
{
    public class SchoolController : Controller
    {
        private IValidator<School> _validator;
        private ISchoolService _schoolService;
        public SchoolController(IValidator<School> validator, ISchoolService schoolService)
        {
            _validator = validator;
            _schoolService = schoolService;
        }
        public async Task<ActionResult> Index()
        {
            var schools = await _schoolService.GetSchools();
            
            return View(schools);
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
                return View(school);
            }

            await _schoolService.AddSchool(school);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var school = await _schoolService.GetSchool(id);

            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }
        

        public async Task<IActionResult> Edit(int id)
        {
            var school = await _schoolService.GetSchool(id);

            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(School school)
        {
            ValidationResult result = await _validator.ValidateAsync(school);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(school);
            }
            await _schoolService.EditSchool(school);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var school = await _schoolService.GetSchool(id);

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
            await _schoolService.DeleteSchool(id);

            return RedirectToAction("Index");
        }
    }
}