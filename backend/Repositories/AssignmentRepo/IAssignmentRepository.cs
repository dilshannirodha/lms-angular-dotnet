using backend.Models;

namespace backend.Repositories.AssignmentRepo
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAssignmentsByCourseIdAsync(string courseId);
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int id);
        Task<bool> AssignmentExistsAsync(int id);
    }
}
