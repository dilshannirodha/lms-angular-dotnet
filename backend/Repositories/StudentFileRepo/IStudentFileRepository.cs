using backend.Models;

namespace backend.Repositories.StudentFileRepo
{
    public interface IStudentFileRepository
    {
        Task<List<StudentFile>> GetAllAsync();
        Task<StudentFile> GetByIdAsync(int id);
        Task<StudentFile> AddAsync(StudentFile file);
        Task<bool> DeleteAsync(int id);
    }

}
