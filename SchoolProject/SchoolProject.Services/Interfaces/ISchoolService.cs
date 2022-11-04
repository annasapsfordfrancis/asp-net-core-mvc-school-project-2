using SchoolProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<ActionResult> AddSchool(School school);
        Task<ActionResult> EditSchool(School school);
        Task<ActionResult> DeleteSchool(int id);
        Task<School> GetSchool(int id);
        Task<List<School>> GetSchools();
    }
}
