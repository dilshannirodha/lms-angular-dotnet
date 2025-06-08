using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.TeacherEnrollmentRepo
{
    public class TeacherEnrollmentRepository : ITeacherEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public TeacherEnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherEnrollment>> GetAllAsync() =>
            await _context.TeacherEnrollments.ToListAsync();

        public async Task<TeacherEnrollment?> GetByIdAsync(int id) =>
            await _context.TeacherEnrollments.FindAsync(id);

        public async Task<TeacherEnrollment> AddAsync(TeacherEnrollment enrollment)
        {
            _context.TeacherEnrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<TeacherEnrollment> UpdateAsync(TeacherEnrollment enrollment)
        {
            _context.TeacherEnrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await _context.TeacherEnrollments.FindAsync(id);
            if (enrollment == null) return false;
            _context.TeacherEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<List<string>> GetCourseIdsByStudentIdAsync(string teacherId)
        {
            return await _context.TeacherEnrollments
                .Where(e => e.TeacherId == teacherId)
                .Select(e => e.CourseId)
                .ToListAsync();
        }


    }
}
