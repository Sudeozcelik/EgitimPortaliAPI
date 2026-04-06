using EgitimPortali.API.Models;
using EgitimPortali.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _repo;
        public EnrollmentsController(IEnrollmentRepository repo) => _repo = repo;

        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll([FromBody] Enrollment enrollment)
        {
            await _repo.EnrollStudentAsync(enrollment);
            return Ok("Kursa başarıyla kayıt olundu.");
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetMyCourses(string studentId) => Ok(await _repo.GetStudentEnrollmentsAsync(studentId));

        [HttpPost("complete/{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            await _repo.CompleteCourseAsync(id);
            return Ok("Kurs tamamlandı ve sertifikanız oluşturuldu!");
        }
    }
}