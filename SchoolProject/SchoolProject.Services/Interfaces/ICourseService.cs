using SchoolProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ActionResult> AddCourse(Course course);
        Task<ActionResult> EditCourse(Course course);
        Task<ActionResult> DeleteCourse(int id);
        Task<Course> GetCourse(int id);
        Task<List<Course>> GetCourses();
    }
}
