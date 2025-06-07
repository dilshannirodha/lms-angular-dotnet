using backend.DTOs;
using backend.Models;

namespace backend.Repositories
{
    public interface IStudentUploadRepository
    {
        Task<StudentUpload> CreateAsync(StudentUpload upload);
        Task<StudentUpload?> GetByIdAsync(int id);
        Task<List<StudentUpload>> GetAllByStudentIdAsync(string studentId);
        Task<StudentUpload> UpdateAsync(int id, UpdateStudentUploadDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
