namespace EgitimPortali.API.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public int ProgressPercentage { get; set; } = 0; // İlerleme durumu
        public bool IsCompleted { get; set; } = false;

        // İlişkiler
        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Certificate Certificate { get; set; } // Bire-bir ilişki
    }
}