using EgitimPortali.API.Models;
using EgitimPortali.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoriesController(ICategoryRepository repo) => _repo = repo;

        // Tümü (Listeleme)
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllCategoriesAsync());

        // Tek bir kategori (ID ile Getir)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = (await _repo.GetAllCategoriesAsync()).FirstOrDefault(x => x.Id == id);
            return category == null ? NotFound("Kategori bulunamadı!") : Ok(category);
        }

        // Yeni Ekle
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await _repo.AddCategoryAsync(category);
            return Ok("Kategori başarıyla eklendi.");
        }

        // Güncelle (ID ile)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if (id != category.Id) return BadRequest("URL'deki ID ile gövdedeki ID uyuşmuyor!");
            await _repo.UpdateCategoryAsync(category);
            return Ok($"{id} numaralı kategori güncellendi.");
        }

        // Sil (ID ile)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteCategoryAsync(id);
            return Ok($"{id} numaralı kategori ve içindeki tüm kurslar silindi.");
        }
    }
}