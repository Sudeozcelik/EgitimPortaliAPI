namespace EgitimPortali.API.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentOrVideoUrl { get; set; }
        public int Order { get; set; } // Ders sırası (1, 2, 3...)

        // İlişki: Hangi kursun dersi?
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}