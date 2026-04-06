using Microsoft.AspNetCore.Mvc;      
using EgitimPortali.API.Models;       
using EgitimPortali.API.Repositories; 
using System.Threading.Tasks;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonRepository _repo;

        public LessonsController(ILessonRepository repo) => _repo = repo;

        // ÇÖZÜM BURADA: Bu metot bir API ucu değil, sadece bir yardımcı metot.
        // Swagger'ın kafasının karışmaması için [NonAction] ekliyoruz.
        [NonAction]
        public ILessonRepository Get_repo() => _repo;

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourse(int courseId) 
        {
            var lessons = await _repo.GetLessonsByCourseIdAsync(courseId);
            return Ok(lessons);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lesson lesson)
        {
            await _repo.AddLessonAsync(lesson);
            return Ok("Ders eklendi.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Lesson lesson)
        {
            if (id != lesson.Id) return BadRequest("ID uyuşmuyor!");
            await _repo.UpdateLessonAsync(lesson);
            return Ok($"{id} numaralı ders güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteLessonAsync(id);
            return Ok("Ders silindi.");
        }
    }
}