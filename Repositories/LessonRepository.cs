using EgitimPortali.API.Data;      // Bu satırı ekledik
using EgitimPortali.API.Models;    // Bu satırı ekledik
using Microsoft.EntityFrameworkCore; // Bu satırı ekledik
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgitimPortali.API.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;
        public LessonRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Lesson>> GetLessonsByCourseIdAsync(int courseId) 
            => await _context.Lessons.Where(l => l.CourseId == courseId).OrderBy(l => l.Order).ToListAsync();

        public async Task AddLessonAsync(Lesson lesson) { _context.Lessons.Add(lesson); await _context.SaveChangesAsync(); }

        public async Task UpdateLessonAsync(Lesson lesson) { _context.Update(lesson); await _context.SaveChangesAsync(); }

        public async Task DeleteLessonAsync(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null) { _context.Lessons.Remove(lesson); await _context.SaveChangesAsync(); }
        }
    }
}