using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.StudentFileRepo
{
    public class StudentFileRepository : IStudentFileRepository
    {
        private readonly AppDbContext _context;

        public StudentFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentFile>> GetAllAsync() =>
            await _context.StudentFiles.ToListAsync();

        public async Task<StudentFile> GetByIdAsync(int id) =>
            await _context.StudentFiles.FindAsync(id);

        public async Task<StudentFile> AddAsync(StudentFile file)
        {
            _context.StudentFiles.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var file = await _context.StudentFiles.FindAsync(id);
            if (file == null) return false;
            _context.StudentFiles.Remove(file);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
