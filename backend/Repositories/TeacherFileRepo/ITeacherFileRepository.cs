using backend.Models;

namespace backend.Repositories.TeacherFileRepo
{
    public interface ITeacherFileRepository
    {
        Task<List<TeacherFile>> GetAllAsync();
        Task<TeacherFile> GetByIdAsync(int id);
        Task<TeacherFile> AddAsync(TeacherFile file);
        Task<bool> DeleteAsync(int id);
    }
}
