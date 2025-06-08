using backend.DTOs.StudentEnrollmentDtos;
using backend.Models;

namespace backend.Services.StudentEnrollmentServices
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentDto>> GetAllAsync();
        Task<EnrollmentDto?> GetByIdAsync(int id);
        Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto dto);
        Task<EnrollmentDto?> UpdateAsync(int id, CreateEnrollmentDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<CourseIdDto>> GetCourseIdsByStudentIdAsync(string studentId);

    }


}
