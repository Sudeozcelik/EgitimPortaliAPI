using EgitimPortali.API.Data;
using EgitimPortali.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CoursesController(AppDbContext context) => _context = context;

        // Tümü (Kategoriler dahil)
        [HttpGet]
        public async Task<IActionResult> GetCourses() 
            => Ok(await _context.Courses.Include(c => c.Category).ToListAsync());

        // Tek bir kurs (ID ile Getir)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Courses.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == id);
            return course == null ? NotFound("Kurs bulunamadı!") : Ok(course);
        }

        // Yeni Kurs Ekle
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok("Kurs başarıyla eklendi.");
        }

        // Güncelle (ID ile)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest("ID uyuşmuyor!");
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok($"{id} numaralı kurs güncellendi.");
        }

        // Sil (ID ile)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok($"{id} ID'li {course.Title} kursu silindi.");
        }
    }
}