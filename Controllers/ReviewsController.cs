using EgitimPortali.API.Data;
using EgitimPortali.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReviewsController(AppDbContext context) => _context = context;

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetReviews(int courseId) 
            => Ok(await _context.Reviews.Where(r => r.CourseId == courseId).ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return Ok("Yorum ve puan eklendi.");
        }
    }
}