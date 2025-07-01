using AutoMapper;
using backend.DTOs.StudentDtos;
using backend.Models;
using backend.Repositories.StudentEnrollmentRepo;
using backend.Repositories.StudentRepo;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services.StudentServices
{

    public class StudentService : IStudentService
    {   private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper , IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<StudentResponseDto> CreateStudentAsync(CreateStudentDto createDto)
        {
            var student = _mapper.Map<Student>(createDto);
            var createdStudent = await _studentRepository.CreateAsync(student);
            return _mapper.Map<StudentResponseDto>(createdStudent);
        }

        public async Task<bool> DeleteStudentAsync(string studentId)
        {
            var data = await _enrollmentRepository.GetCourseIdsByStudentIdAsync(studentId);
            if(data.Count > 0)
            {
                throw new Exception("Student is already assigned to courses!");
            }
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
