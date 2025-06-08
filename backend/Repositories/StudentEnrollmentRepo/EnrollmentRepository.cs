using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.StudentEnrollmentRepo
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllAsync() =>
            await _context.Enrollments.ToListAsync();

        public async Task<Enrollment?> GetByIdAsync(int id) =>
            await _context.Enrollments.FindAsync(id);

        public async Task<Enrollment> AddAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> UpdateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return false;
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<List<string>> GetCourseIdsByStudentIdAsync(string studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Select(e => e.CourseId)
                .ToListAsync();
        }


    }


}
