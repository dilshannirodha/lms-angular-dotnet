using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class StudentUploadService : IStudentUploadService
    {
        private readonly IStudentUploadRepository _uploadRepository;
        private readonly IMapper _mapper;

        public StudentUploadService(IStudentUploadRepository uploadRepository, IMapper mapper)
        {
            _uploadRepository = uploadRepository;
            _mapper = mapper;
        }

        public async Task<StudentUploadResponseDto> CreateStudentUploadAsync(CreateStudentUploadDto createDto)
        {
            var upload = _mapper.Map<StudentUpload>(createDto);
            var createdUpload = await _uploadRepository.CreateAsync(upload);
            return _mapper.Map<StudentUploadResponseDto>(createdUpload);
        }

        public async Task<bool> DeleteStudentUploadAsync(int id)
        {
            return await _uploadRepository.DeleteAsync(id);
        }

        public async Task<List<StudentUploadResponseDto>> GetAllStudentUploadsAsync(string studentId)
        {
            var uploads = await _uploadRepository.GetAllByStudentIdAsync(studentId);
            return _mapper.Map<List<StudentUploadResponseDto>>(uploads);
        }

        public async Task<StudentUploadResponseDto?> GetStudentUploadByIdAsync(int id)
        {
            var upload = await _uploadRepository.GetByIdAsync(id);
            return upload == null ? null : _mapper.Map<StudentUploadResponseDto>(upload);
        }

        public async Task<StudentUploadResponseDto> UpdateStudentUploadAsync(int id, UpdateStudentUploadDto updateDto)
        {
            var upload = await _uploadRepository.UpdateAsync(id, updateDto);
            return _mapper.Map<StudentUploadResponseDto>(upload);
        }
    }
}
