using EgitimPortali.API.Models;

namespace EgitimPortali.API.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        // Yeni eklenenler:
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}