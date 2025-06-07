using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.TeacherFileRepo
{
    public class TeacherFileRepository: ITeacherFileRepository
    {

        private readonly AppDbContext _context;

        public TeacherFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherFile>> GetAllAsync() =>
            await _context.TeacherFiles.ToListAsync();

        public async Task<TeacherFile> GetByIdAsync(int id) =>
            await _context.TeacherFiles.FindAsync(id);

        public async Task<TeacherFile> AddAsync(TeacherFile file)
        {
            _context.TeacherFiles.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var file = await _context.TeacherFiles.FindAsync(id);
            if (file == null) return false;
            _context.TeacherFiles.Remove(file);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
