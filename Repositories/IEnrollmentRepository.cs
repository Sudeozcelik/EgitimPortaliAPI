using EgitimPortali.API.Models;

namespace EgitimPortali.API.Repositories
{
    public interface IEnrollmentRepository
    {
        Task EnrollStudentAsync(Enrollment enrollment);
        Task<IEnumerable<Enrollment>> GetStudentEnrollmentsAsync(string studentId);
        Task CompleteCourseAsync(int enrollmentId); // Kurs bittiğinde sertifika tetiklensin
    }
}