using backend.DTOs.TeacherDtos;
using backend.Models;

namespace backend.Repositories.TeacherRepo
{
    public interface ITeacherRepository
    {
        Task<Teacher> CreateAsync(Teacher teacher);
        Task<Teacher?> GetByIdAsync(string teacherId);
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> UpdateAsync(string teacherId, UpdateTeacherDto updateDto);
        Task<bool> DeleteAsync(string teacherId);
    }
}
