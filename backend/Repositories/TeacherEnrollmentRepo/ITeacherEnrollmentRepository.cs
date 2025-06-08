using backend.Models;

namespace backend.Repositories.TeacherEnrollmentRepo
{
    public interface ITeacherEnrollmentRepository
    {
        Task<List<TeacherEnrollment>> GetAllAsync();
        Task<TeacherEnrollment?> GetByIdAsync(int id);
        Task<TeacherEnrollment> AddAsync(TeacherEnrollment enrollment);
        Task<TeacherEnrollment> UpdateAsync(TeacherEnrollment enrollment);
        Task<bool> DeleteAsync(int id);
        Task<List<string>> GetCourseIdsByStudentIdAsync(string studentId);

    }
}
