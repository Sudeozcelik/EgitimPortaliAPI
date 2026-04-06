namespace EgitimPortali.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; } // 1 ile 5 arası
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        // İlişkiler
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}