using backend.DTOs.TeacherDtos;

namespace backend.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<TeacherResponseDto> CreateTeacherAsync(CreateTeacherDto createDto);
        Task<TeacherResponseDto?> GetTeacherByIdAsync(string teacherId);
        Task<List<TeacherResponseDto>> GetAllTeachersAsync();
        Task<TeacherResponseDto> UpdateTeacherAsync(string teacherId, UpdateTeacherDto updateDto);
        Task<bool> DeleteTeacherAsync(string teacherId);
    }
}
