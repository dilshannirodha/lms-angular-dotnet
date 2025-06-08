using backend.DTOs.TeacherEnrollmentDtos;
using backend.Models;
using backend.Repositories.TeacherEnrollmentRepo;

namespace backend.Services.TeacherEnrollmentServices
{
    public class TeacherEnrollmentService:ITeacherEnrollmentService
    {
        private readonly ITeacherEnrollmentRepository _repo;

        public TeacherEnrollmentService(ITeacherEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TeacherEnrollmentDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new TeacherEnrollmentDto
            {
                Id = e.Id,
                CourseId = e.CourseId,
                TeacherId = e.TeacherId,
                EnrolledAt = e.EnrolledAt
            }).ToList();
        }

        public async Task<TeacherEnrollmentDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;
            return new TeacherEnrollmentDto
            {
                Id = e.Id,
                CourseId = e.CourseId,
                TeacherId = e.TeacherId,
                EnrolledAt = e.EnrolledAt
            };
        }

        public async Task<TeacherEnrollmentDto> CreateAsync(CreateTeacherEnrollmentDto dto)
        {
            var e = new TeacherEnrollment
            {
                CourseId = dto.CourseId,
                TeacherId = dto.TeacherId
            };
            var created = await _repo.AddAsync(e);
            return new TeacherEnrollmentDto
            {
                Id = created.Id,
                CourseId = created.CourseId,
                TeacherId = created.TeacherId,
                EnrolledAt = created.EnrolledAt
            };
        }

        public async Task<TeacherEnrollmentDto?> UpdateAsync(int id, CreateTeacherEnrollmentDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.CourseId = dto.CourseId;
            existing.TeacherId = dto.TeacherId;

            var updated = await _repo.UpdateAsync(existing);
            return new TeacherEnrollmentDto
            {
                Id = updated.Id,
                CourseId = updated.CourseId,
                TeacherId = updated.TeacherId,
                EnrolledAt = updated.EnrolledAt
            };
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);




        public async Task<List<TeacherCourseIdDto>> GetCourseIdsByTeacherIdAsync(string teacherId)
        {
            var courseIds = await _repo.GetCourseIdsByStudentIdAsync(teacherId);
            return courseIds.Select(cid => new TeacherCourseIdDto { CourseId = cid }).ToList();
        }


    }
}
