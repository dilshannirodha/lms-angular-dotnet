using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(string studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(string studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<Student> UpdateAsync(string studentId, UpdateStudentDto updateDto)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null) return null;

            if (!string.IsNullOrEmpty(updateDto.Name)) student.Name = updateDto.Name;
            if (!string.IsNullOrEmpty(updateDto.Address)) student.Address = updateDto.Address;
            if (!string.IsNullOrEmpty(updateDto.Email)) student.Email = updateDto.Email;
            if (!string.IsNullOrEmpty(updateDto.Phone)) student.Phone = updateDto.Phone;

            await _context.SaveChangesAsync();
            return student;
        }
    }
}
