using backend.Data;
using backend.DTOs.TeacherDtos;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.TeacherRepo
{
    public class TeacherRepository: ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<bool> DeleteAsync(string teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(string teacherId)
        {
            return await _context.Teachers.FindAsync(teacherId);
        }

        public async Task<Teacher> UpdateAsync(string teacherId, UpdateTeacherDto updateDto)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher == null) return null;
            if (!string.IsNullOrEmpty(updateDto.Name)) teacher.Username = updateDto.Username;
            if (!string.IsNullOrEmpty(updateDto.Name)) teacher.Name = updateDto.Name;
            if (!string.IsNullOrEmpty(updateDto.Subject)) teacher.Subject = updateDto.Subject;
            if (!string.IsNullOrEmpty(updateDto.Email)) teacher.Email = updateDto.Email;
            if (!string.IsNullOrEmpty(updateDto.Phone)) teacher.Phone = updateDto.Phone;

            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
