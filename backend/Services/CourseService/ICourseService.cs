using backend.DTOs.CourseDtos;

namespace backend.Services.CourseService
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(string courseId);
        Task<CourseDto> CreateAsync(CreateCourseDto dto);
        Task<CourseDto?> UpdateAsync(string courseId, UpdateCourseDto dto);
        Task<bool> DeleteAsync(string courseId);
        Task<CourseNameDto?> GetCourseNameByIdAsync(string courseId);

    }
}
