using backend.DTOs.UploadFilesDtos;
using backend.Models;
using backend.Repositories.UploadedFileRepo;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.UploadedFileServices
{
    public class UploadedFileService : IUploadedFileService
    {
        private readonly IUploadedFileRepository _repository;

        public UploadedFileService(IUploadedFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<UploadedFileDto> UploadAsync(UploadFileDto dto)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream);

            var file = new UploadedFile
            {
                Username = dto.Username,
                FileName = dto.File.FileName,
                FileData = memoryStream.ToArray(),
                CreatedDate = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(file);

            return new UploadedFileDto
            {
                Id = result.Id,
                Username = result.Username,
                FileName = result.FileName,
                CreatedDate = result.CreatedDate
            };
        }

        public async Task<List<UploadedFileDto>> GetAllAsync()
        {
            var files = await _repository.GetAllAsync();
            return files.Select(f => new UploadedFileDto
            {
                Id = f.Id,
                Username = f.Username,
                FileName = f.FileName,
                CreatedDate = f.CreatedDate
            }).ToList();
        }

        public async Task<FileResult?> DownloadAsync(int id)
        {
            var file = await _repository.GetByIdAsync(id);
            if (file == null) return null;

            return new FileContentResult(file.FileData, "application/octet-stream")
            {
                FileDownloadName = file.FileName
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
