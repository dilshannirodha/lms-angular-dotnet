using backend.DTOs;

namespace backend.Services
{
    public interface IStudentService
    {
        Task<StudentResponseDto> CreateStudentAsync(CreateStudentDto createDto);
        Task<StudentResponseDto?> GetStudentByIdAsync(string studentId);
        Task<List<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto> UpdateStudentAsync(string studentId, UpdateStudentDto updateDto);
        Task<bool> DeleteStudentAsync(string studentId);
    }
}
