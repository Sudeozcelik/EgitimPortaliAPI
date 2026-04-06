using EgitimPortali.API.Data;
using EgitimPortali.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() => await _context.Categories.ToListAsync();
        public async Task AddCategoryAsync(Category category) { await _context.Categories.AddAsync(category); await _context.SaveChangesAsync(); }
   public async Task UpdateCategoryAsync(Category category)
{
    _context.Categories.Update(category);
    await _context.SaveChangesAsync();
}

public async Task DeleteCategoryAsync(int id)
{
    var category = await _context.Categories.FindAsync(id);
    if (category != null)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
   
    }
}