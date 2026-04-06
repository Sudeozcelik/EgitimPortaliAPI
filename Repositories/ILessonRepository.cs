using EgitimPortali.API.Models; // Bu satırı ekledik
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgitimPortali.API.Repositories
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessonsByCourseIdAsync(int courseId);
        Task AddLessonAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(int id);
    }
}