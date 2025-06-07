using backend.DTOs.StudentDtos;

namespace backend.Services.StudentServices
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
