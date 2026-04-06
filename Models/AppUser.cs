using Microsoft.AspNetCore.Identity;

namespace EgitimPortali.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        // İlişkiler (Navigation Properties)
        public ICollection<Course> TaughtCourses { get; set; } // Eğitmense verdiği kurslar
        public ICollection<Enrollment> Enrollments { get; set; } // Öğrenciyse aldığı kurslar
        public ICollection<Review> Reviews { get; set; } // Yaptığı yorumlar
        public ICollection<Notification> Notifications { get; set; } // Gelen bildirimler
    }
}