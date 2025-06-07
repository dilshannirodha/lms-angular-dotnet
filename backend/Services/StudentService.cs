using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponseDto> CreateStudentAsync(CreateStudentDto createDto)
        {
            var student = _mapper.Map<Student>(createDto);
            var createdStudent = await _studentRepository.CreateAsync(student);
            return _mapper.Map<StudentResponseDto>(createdStudent);
        }

        public async Task<bool> DeleteStudentAsync(string studentId)
        {
            return await _studentRepository.DeleteAsync(studentId);
        }

        public async Task<List<StudentResponseDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentResponseDto>>(students);
        }

        public async Task<StudentResponseDto?> GetStudentByIdAsync(string studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            return student == null ? null : _mapper.Map<StudentResponseDto>(student);
        }

        public async Task<StudentResponseDto> UpdateStudentAsync(string studentId, UpdateStudentDto updateDto)
        {
            var student = await _studentRepository.UpdateAsync(studentId, updateDto);
            return _mapper.Map<StudentResponseDto>(student);
        }
    }
}
