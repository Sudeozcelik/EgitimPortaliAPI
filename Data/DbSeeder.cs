using EgitimPortali.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // 1. Önce kategorileri garantiye alalım
            if (!await context.Categories.AnyAsync())
            {
                var cats = new List<Category>
                {
                    new Category { Name = "Yazılım", Description = "Yazılım eğitimleri." },
                    new Category { Name = "Tasarım", Description = "Tasarım eğitimleri." }
                };
                await context.Categories.AddRangeAsync(cats);
                await context.SaveChangesAsync();
            }

            // 2. Şimdi kursu ekleyelim ama önce kategorinin ID'sini bulalım
            if (!await context.Courses.AnyAsync())
            {
                var firstCat = await context.Categories.FirstOrDefaultAsync();
                
                if (firstCat != null) // Kategori varsa ekle
                {
                    await context.Courses.AddAsync(new Course
                    {
                        Title = ".NET Core Giriş",
                        Description = "Örnek Kurs",
                        Price = 100,
                        CategoryId = firstCat.Id,
                        InstructorId = null // Burası kritik: Nullable olduğunu SQL'e gösteriyoruz
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}