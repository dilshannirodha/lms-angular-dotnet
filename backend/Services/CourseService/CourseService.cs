using backend.DTOs.CourseDtos;
using backend.Models;
using backend.Repositories.CourseRepo;

namespace backend.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;

        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _repo.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Assignment = c.Assignment
            }).ToList();
        }

        public async Task<CourseDto?> GetByIdAsync(string courseId)
        {
            var course = await _repo.GetByIdAsync(courseId);
            if (course == null) return null;

            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Assignment = course.Assignment
            };
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                CourseId = dto.CourseId,
                CourseName = dto.CourseName,
                Assignment = dto.Assignment
            };
            var created = await _repo.CreateAsync(course);
            return new CourseDto
            {
                CourseId = created.CourseId,
                CourseName = created.CourseName,
                Assignment = created.Assignment
            };
        }

        public async Task<CourseDto?> UpdateAsync(string courseId, UpdateCourseDto dto)
        {
            var existing = await _repo.GetByIdAsync(courseId);
            if (existing == null) return null;

            existing.CourseName = dto.CourseName;
            existing.Assignment = dto.Assignment;

            var updated = await _repo.UpdateAsync(existing);
            return new CourseDto
            {
                CourseId = updated.CourseId,
                CourseName = updated.CourseName,
                Assignment = updated.Assignment
            };
        }

        public async Task<bool> DeleteAsync(string courseId) => await _repo.DeleteAsync(courseId);

        public async Task<CourseNameDto?> GetCourseNameByIdAsync(string courseId)
        {
            return await _repo.GetCourseNameByIdAsync(courseId);
        }
    }
}
