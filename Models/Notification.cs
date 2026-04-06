namespace EgitimPortali.API.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;

        // İlişkiler
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}