using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly SchoolProjectDbContext _context;
        public CourseService(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> AddCourse(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> EditCourse(Course course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteCourse(int id)
        {
            var course = await GetCourse(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<Course> GetCourse(int id)
        {
            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);

            return course;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _context.Course.ToListAsync();

            return courses;
        }
    }
}
