using Microsoft.AspNetCore.Identity;

namespace EgitimPortali.API.Models
{
    public class AppUser : IdentityUser<int> // <int> eklemeyi unutma!
    {
        // AuthController'ın istediği alanlar:
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // Bizim eklediğimiz Admin yetki alanı:
        public string Role { get; set; } = "Student";
    }
}