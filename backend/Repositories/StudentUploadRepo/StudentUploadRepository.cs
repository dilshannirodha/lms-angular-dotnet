using backend.Data;
using backend.DTOs.StudentUploadDtos;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.studentUpload
{
    public class StudentUploadRepository : IStudentUploadRepository
    {
        private readonly AppDbContext _context;

        public StudentUploadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentUpload> CreateAsync(StudentUpload upload)
        {
            await _context.StudentUploads.AddAsync(upload);
            await _context.SaveChangesAsync();
            return upload;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var upload = await _context.StudentUploads.FindAsync(id);
            if (upload == null) return false;

            _context.StudentUploads.Remove(upload);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudentUpload>> GetAllByStudentIdAsync(string studentId)
        {
            return await _context.StudentUploads
                .Where(u => u.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<StudentUpload?> GetByIdAsync(int id)
        {
            return await _context.StudentUploads.FindAsync(id);
        }

        public async Task<StudentUpload> UpdateAsync(int id, UpdateStudentUploadDto updateDto)
        {
            var upload = await _context.StudentUploads.FindAsync(id);
            if (upload == null) return null;

            if (!string.IsNullOrEmpty(updateDto.Subject)) upload.Subject = updateDto.Subject;
            if (updateDto.Uploads != null) upload.Uploads = updateDto.Uploads;
            if (updateDto.Marks.HasValue) upload.Marks = updateDto.Marks.Value;
            if (!string.IsNullOrEmpty(updateDto.Feedback)) upload.Feedback = updateDto.Feedback;

            await _context.SaveChangesAsync();
            return upload;
        }
    }
}
