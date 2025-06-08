using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.UploadedFileRepo
{
    public class UploadedFileRepository : IUploadedFileRepository
    {
        private readonly AppDbContext _context;

        public UploadedFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UploadedFile> AddAsync(UploadedFile file)
        {
            _context.UploadedFiles.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<List<UploadedFile>> GetAllAsync()
        {
            return await _context.UploadedFiles.ToListAsync();
        }

        public async Task<UploadedFile?> GetByIdAsync(int id)
        {
            return await _context.UploadedFiles.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var file = await _context.UploadedFiles.FindAsync(id);
            if (file != null)
            {
                _context.UploadedFiles.Remove(file);
                await _context.SaveChangesAsync();
            }
        }
    }

}
