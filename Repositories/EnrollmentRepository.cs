using EgitimPortali.API.Data;
using EgitimPortali.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.API.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context) => _context = context;

        public async Task EnrollStudentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetStudentEnrollmentsAsync(string studentId)
        {
            return await _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task CompleteCourseAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment != null)
            {
                enrollment.IsCompleted = true;
                enrollment.ProgressPercentage = 100;

                // Otomatik Sertifika Oluşturma
                var certificate = new Certificate
                {
                    EnrollmentId = enrollmentId,
                    IssueDate = DateTime.Now,
                    CertificateNumber = "CERT-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper()
                };
                await _context.Certificates.AddAsync(certificate);
                
                await _context.SaveChangesAsync();
            }
        }
    }
}