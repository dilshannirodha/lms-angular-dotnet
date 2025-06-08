using backend.DTOs.AssignmentDtos;

namespace backend.Services.AssignmentServices
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentDto>> GetAssignmentsByCourseIdAsync(string courseId);
        Task<AssignmentDto> GetAssignmentByIdAsync(int id);
        Task<AssignmentDto> CreateAssignmentAsync(CreateAssignmentDto createDto);
        Task<bool> UpdateAssignmentAsync(int id, UpdateAssignmentDto updateDto);
        Task<bool> DeleteAssignmentAsync(int id);
    }

}
