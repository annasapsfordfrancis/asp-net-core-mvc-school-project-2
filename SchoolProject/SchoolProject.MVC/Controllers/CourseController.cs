using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.MVC.Controllers
{
    public class CourseController : Controller
    {
        private IValidator<Course> _validator;
        private ICourseService _courseService;
        public CourseController(IValidator<Course> validator, ICourseService courseService)
        {
            _validator = validator;
            _courseService = courseService;
        }
        public async Task<ActionResult> Index()
        {
            var courses = await _courseService.GetCourses();

            return View(courses);
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
            await _courseService.AddCourse(course);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourse(id);

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
            await _courseService.EditCourse(course);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourse(id);

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
            await _courseService.DeleteCourse(id);

            return RedirectToAction("Index");
        }
    }
}