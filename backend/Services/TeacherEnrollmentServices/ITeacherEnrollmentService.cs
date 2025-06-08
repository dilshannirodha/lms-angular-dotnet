using backend.DTOs.TeacherEnrollmentDtos;

namespace backend.Services.TeacherEnrollmentServices
{
    public interface ITeacherEnrollmentService
    {
        Task<List<TeacherEnrollmentDto>> GetAllAsync();
        Task<TeacherEnrollmentDto?> GetByIdAsync(int id);
        Task<TeacherEnrollmentDto> CreateAsync(CreateTeacherEnrollmentDto dto);
        Task<TeacherEnrollmentDto?> UpdateAsync(int id, CreateTeacherEnrollmentDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<TeacherCourseIdDto>> GetCourseIdsByTeacherIdAsync(string teacherId);
    }
}
