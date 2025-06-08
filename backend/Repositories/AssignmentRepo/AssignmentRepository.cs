using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.AssignmentRepo
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _context;

        public AssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByCourseIdAsync(string courseId)
        {
            return await _context.Assignments
                .Where(a => a.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var assignment = await GetAssignmentByIdAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AssignmentExistsAsync(int id)
        {
            return await _context.Assignments.AnyAsync(a => a.Id == id);
        }
    }

}
