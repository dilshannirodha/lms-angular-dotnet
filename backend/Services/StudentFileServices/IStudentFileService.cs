using backend.DTOs.StudentFilesDtos;

namespace backend.Services.StudentFileServices
{
    public interface IStudentFileService
    {
        Task<List<StudentFileDto>> GetAllAsync();
        Task<StudentFileDto> GetByIdAsync(int id);
        Task<StudentFileDto> UploadAsync(CreateStudentFileDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
