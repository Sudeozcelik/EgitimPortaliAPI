using EgitimPortali.API.Data;
using EgitimPortali.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Course>> GetAllCoursesAsync() 
            => await _context.Courses.Include(c => c.Category).ToListAsync(); // Kategorisiyle birlikte getir

        public async Task<Course> GetCourseByIdAsync(int id) 
            => await _context.Courses.Include(c => c.Lessons).FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}