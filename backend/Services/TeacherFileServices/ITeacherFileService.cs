using backend.DTOs.StudentFilesDtos;
using backend.DTOs.TeacherFileDtos;

namespace backend.Services.TeacherFileServices
{
    public interface ITeacherFileService
    {
        Task<List<TeacherFileDto>> GetAllAsync();
        Task<TeacherFileDto> GetByIdAsync(int id);
        Task<TeacherFileDto> UploadAsync(CreateTeacherFileDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
