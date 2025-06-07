using backend.DTOs.StudentFilesDtos;
using backend.Models;
using backend.Repositories.StudentFileRepo;

namespace backend.Services.StudentFileServices
{
    public class StudentFileService : IStudentFileService
    {
        private readonly IStudentFileRepository _repository;
        private readonly IWebHostEnvironment _env;

        public StudentFileService(IStudentFileRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task<List<StudentFileDto>> GetAllAsync()
        {
            var files = await _repository.GetAllAsync();
            return files.Select(f => new StudentFileDto
            {
                Id = f.Id,
                StudentId = f.StudentId,
                FileName = f.FileName,
                FilePath = f.FilePath,
                UploadedAt = f.UploadedAt
            }).ToList();
        }

        public async Task<StudentFileDto> GetByIdAsync(int id)
        {
            var f = await _repository.GetByIdAsync(id);
            if (f == null) return null;
            return new StudentFileDto
            {
                Id = f.Id,
                StudentId = f.StudentId,
                FileName = f.FileName,
                FilePath = f.FilePath,
                UploadedAt = f.UploadedAt
            };
        }

        public async Task<StudentFileDto> UploadAsync(CreateStudentFileDto dto)
        {
            var folderPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "studentfiles");
            Directory.CreateDirectory(folderPath);

            var uniqueName = Guid.NewGuid() + Path.GetExtension(dto.File.FileName);
            var filePath = Path.Combine(folderPath, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var file = new StudentFile
            {
                StudentId = dto.StudentId,
                FileName = dto.File.FileName,
                FilePath = $"/studentfiles/{uniqueName}",
                UploadedAt = DateTime.UtcNow
            };

            var added = await _repository.AddAsync(file);
            return await GetByIdAsync(added.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}
