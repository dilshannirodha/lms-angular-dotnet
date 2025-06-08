using backend.Models;

namespace backend.Repositories.StudentEnrollmentRepo
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync();
        Task<Enrollment?> GetByIdAsync(int id);
        Task<Enrollment> AddAsync(Enrollment enrollment);
        Task<Enrollment> UpdateAsync(Enrollment enrollment);
        Task<bool> DeleteAsync(int id);
        Task<List<string>> GetCourseIdsByStudentIdAsync(string studentId);

    }


}
