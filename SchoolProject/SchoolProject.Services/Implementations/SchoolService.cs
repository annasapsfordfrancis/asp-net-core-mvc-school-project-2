using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Services.Interfaces;

namespace SchoolProject.Services.Implementations
{
    public class SchoolService : ISchoolService
    {
        private readonly SchoolProjectDbContext _context;
        public SchoolService(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> AddSchool(School school)
        {
            await _context.School.AddAsync(school);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> EditSchool(School school)
        {
            _context.Update(school);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> DeleteSchool(int id)
        {
            var school = await GetSchool(id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<School> GetSchool(int id)
        {
            var school = await _context.School
                .FirstOrDefaultAsync(m => m.SchoolId == id);

            return school;
        }

        public async Task<List<School>> GetSchools()
        {
            var schools = await _context.School.ToListAsync();

            return schools;
        }
    }
}
