﻿using backend.DTOs.StudentDtos;
using backend.Models;

namespace backend.Repositories.StudentRepo
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<Student?> GetByIdAsync(string studentId);
        Task<List<Student>> GetAllAsync();
        Task<Student> UpdateAsync(string studentId, UpdateStudentDto updateDto);
        Task<bool> DeleteAsync(string studentId);
    }
}
