using backend.DTOs.StudentFilesDtos;
using backend.DTOs.TeacherFileDtos;
using backend.Models;
using backend.Repositories.StudentFileRepo;
using backend.Repositories.TeacherFileRepo;

namespace backend.Services.TeacherFileServices
{
    public class TeacherFileService: ITeacherFileService
    {
        private readonly ITeacherFileRepository _repository;
        private readonly IWebHostEnvironment _env;

        public TeacherFileService(ITeacherFileRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task<List<TeacherFileDto>> GetAllAsync()
        {
            var files = await _repository.GetAllAsync();
            return files.Select(f => new TeacherFileDto
            {
                Id = f.Id,
                TeacherId = f.TeacherId,
                FileName = f.FileName,
                FilePath = f.FilePath,
                UploadedAt = f.UploadedAt
            }).ToList();
        }

        public async Task<TeacherFileDto> GetByIdAsync(int id)
        {
            var f = await _repository.GetByIdAsync(id);
            if (f == null) return null;
            return new TeacherFileDto
            {
                Id = f.Id,
                TeacherId = f.TeacherId,
                FileName = f.FileName,
                FilePath = f.FilePath,
                UploadedAt = f.UploadedAt
            };
        }

        public async Task<TeacherFileDto> UploadAsync(CreateTeacherFileDto dto)
        {
            var folderPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "teacherfiles");
            Directory.CreateDirectory(folderPath);

            var uniqueName = Guid.NewGuid() + Path.GetExtension(dto.File.FileName);
            var filePath = Path.Combine(folderPath, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var file = new TeacherFile
            {
                TeacherId = dto.TeacherId,
                FileName = dto.File.FileName,
                FilePath = $"/teacherfiles/{uniqueName}",
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
