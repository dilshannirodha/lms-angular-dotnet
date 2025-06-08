using backend.DTOs.CourseDtos;
using backend.Models;

namespace backend.Repositories.CourseRepo
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(string courseId);
        Task<Course> CreateAsync(Course course);
        Task<Course> UpdateAsync(Course course);
        Task<bool> DeleteAsync(string courseId);
        Task<CourseNameDto?> GetCourseNameByIdAsync(string courseId);

    }
}
