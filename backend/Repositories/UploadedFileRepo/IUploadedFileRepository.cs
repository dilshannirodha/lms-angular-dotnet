using backend.Models;

namespace backend.Repositories.UploadedFileRepo
{
    public interface IUploadedFileRepository
    {
        Task<UploadedFile> AddAsync(UploadedFile file);
        Task<List<UploadedFile>> GetAllAsync();
        Task<UploadedFile?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }

}
