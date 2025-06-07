using backend.DTOs.StudentUploadDtos;

namespace backend.Services.StudentUploadServices
{

    public interface IStudentUploadService
    {
        Task<StudentUploadResponseDto> CreateStudentUploadAsync(CreateStudentUploadDto createDto);
        Task<StudentUploadResponseDto?> GetStudentUploadByIdAsync(int id);
        Task<List<StudentUploadResponseDto>> GetAllStudentUploadsAsync(string studentId);
        Task<StudentUploadResponseDto> UpdateStudentUploadAsync(int id, UpdateStudentUploadDto updateDto);
        Task<bool> DeleteStudentUploadAsync(int id);
    }
}
