using backend.DTOs.AssignmentDtos;
using backend.Models;
using backend.Repositories.AssignmentRepo;

namespace backend.Services.AssignmentServices
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _repository;

        public AssignmentService(IAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssignmentDto>> GetAssignmentsByCourseIdAsync(string courseId)
        {
            var assignments = await _repository.GetAssignmentsByCourseIdAsync(courseId);
            return assignments.Select(a => new AssignmentDto
            {
                Id = a.Id,
                CourseId = a.CourseId,
                AssignmentText = a.AssignmentText,
                DueDate = a.DueDate
            });
        }

        public async Task<AssignmentDto> GetAssignmentByIdAsync(int id)
        {
            var assignment = await _repository.GetAssignmentByIdAsync(id);
            if (assignment == null) return null;

            return new AssignmentDto
            {
                Id = assignment.Id,
                CourseId = assignment.CourseId,
                AssignmentText = assignment.AssignmentText,
                DueDate = assignment.DueDate
            };
        }

        public async Task<AssignmentDto> CreateAssignmentAsync(CreateAssignmentDto createDto)
        {
            var assignment = new Assignment
            {
                CourseId = createDto.CourseId,
                AssignmentText = createDto.AssignmentText,
                DueDate = createDto.DueDate
            };

            var created = await _repository.CreateAssignmentAsync(assignment);

            return new AssignmentDto
            {
                Id = created.Id,
                CourseId = created.CourseId,
                AssignmentText = created.AssignmentText,
                DueDate = created.DueDate
            };
        }

        public async Task<bool> UpdateAssignmentAsync(int id, UpdateAssignmentDto updateDto)
        {
            var exists = await _repository.AssignmentExistsAsync(id);
            if (!exists) return false;

            var assignment = await _repository.GetAssignmentByIdAsync(id);
            assignment.AssignmentText = updateDto.AssignmentText;

            await _repository.UpdateAssignmentAsync(assignment);
            return true;
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            var exists = await _repository.AssignmentExistsAsync(id);
            if (!exists) return false;

            await _repository.DeleteAssignmentAsync(id);
            return true;
        }
    }

}
