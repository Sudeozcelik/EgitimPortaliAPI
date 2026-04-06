namespace EgitimPortali.API.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateNumber { get; set; } = Guid.NewGuid().ToString();
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public string DownloadUrl { get; set; }

        // İlişkiler
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}