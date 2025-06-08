using backend.DTOs.StudentEnrollmentDtos;
using backend.Models;
using backend.Repositories.StudentEnrollmentRepo;
using backend.Services.StudentEnrollmentServices;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.StudentEnrollmentServices
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repo;

        public EnrollmentService(IEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EnrollmentDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new EnrollmentDto
            {
                Id = e.Id,
                CourseId = e.CourseId,
                StudentId = e.StudentId,
                EnrolledAt = e.EnrolledAt
            }).ToList();
        }

        public async Task<EnrollmentDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;
            return new EnrollmentDto
            {
                Id = e.Id,
                CourseId = e.CourseId,
                StudentId = e.StudentId,
                EnrolledAt = e.EnrolledAt
            };
        }

        public async Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto dto)
        {
            var e = new Enrollment
            {
                CourseId = dto.CourseId,
                StudentId = dto.StudentId
            };
            var created = await _repo.AddAsync(e);
            return new EnrollmentDto
            {
                Id = created.Id,
                CourseId = created.CourseId,
                StudentId = created.StudentId,
                EnrolledAt = created.EnrolledAt
            };
        }

        public async Task<EnrollmentDto?> UpdateAsync(int id, CreateEnrollmentDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.CourseId = dto.CourseId;
            existing.StudentId = dto.StudentId;

            var updated = await _repo.UpdateAsync(existing);
            return new EnrollmentDto
            {
                Id = updated.Id,
                CourseId = updated.CourseId,
                StudentId = updated.StudentId,
                EnrolledAt = updated.EnrolledAt
            };
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);




        public async Task<List<CourseIdDto>> GetCourseIdsByStudentIdAsync(string studentId)
        {
            var courseIds = await _repo.GetCourseIdsByStudentIdAsync(studentId);
            return courseIds.Select(cid => new CourseIdDto { CourseId = cid }).ToList();
        }


    }

}
