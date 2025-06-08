using backend.Data;
using backend.DTOs.CourseDtos;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.CourseRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllAsync() =>
            await _context.Courses.ToListAsync();

        public async Task<Course?> GetByIdAsync(string courseId) =>
            await _context.Courses.FindAsync(courseId);

        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteAsync(string courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CourseNameDto?> GetCourseNameByIdAsync(string courseId)
        {
            var course = await _context.Courses
                .Where(c => c.CourseId == courseId)
                .Select(c => new CourseNameDto { CourseName = c.CourseName })
                .FirstOrDefaultAsync();

            return course;
        }
    }
}
