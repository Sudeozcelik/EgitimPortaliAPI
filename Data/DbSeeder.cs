using EgitimPortali.API.Models;
using System.Linq;
using System.Threading.Tasks; // Bu satır önemli

namespace EgitimPortali.API.Data
{
    public static class DbSeeder
    {
        // İsmi "SeedAsync" yaptık ve "Task" ekledik ki hata çözülsün
        public static async Task SeedAsync(AppDbContext context)
        {
            // Veritabanı yoksa oluşturur (Asenkron versiyonu)
            await context.Database.EnsureCreatedAsync();

            // 1. ADMİN KULLANICI EKLEME
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                var adminUser = new AppUser
                {
                    FirstName = "Sistem",
                    LastName = "Yoneticisi",
                    Email = "admin@egitim.com",
                    UserName = "admin@egitim.com",
                    Role = "Admin",
                    EmailConfirmed = true
                };

                adminUser.PasswordHash = "admin123"; 

                context.Users.Add(adminUser);
            }

            // 2. ÖRNEK KATEGORİ EKLEME
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "Yazılım" });
                context.Categories.Add(new Category { Name = "Tasarım" });
            }

            // Değişiklikleri kaydet (Asenkron versiyonu)
            await context.SaveChangesAsync();
        }
    }
}