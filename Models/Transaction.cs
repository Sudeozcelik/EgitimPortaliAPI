namespace EgitimPortali.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; } // "Kredi Kartı", "Havale" vb.

        // İlişkiler
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}