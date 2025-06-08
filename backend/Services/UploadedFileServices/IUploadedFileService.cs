using backend.DTOs.UploadFilesDtos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.UploadedFileServices
{
    public interface IUploadedFileService
    {
        Task<UploadedFileDto> UploadAsync(UploadFileDto dto);
        Task<List<UploadedFileDto>> GetAllAsync();
        Task<FileResult?> DownloadAsync(int id);
        Task DeleteAsync(int id);
    }

}
