using AutoMapper;
using backend.DTOs.TeacherDtos;
using backend.Models;
using backend.Repositories.TeacherRepo;

namespace backend.Services.TeacherServices
{
    public class TeacherService: ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<TeacherResponseDto> CreateTeacherAsync(CreateTeacherDto createDto)
        {
            var teacher = _mapper.Map<Teacher>(createDto);
            var createdTeacher = await _teacherRepository.CreateAsync(teacher);
            return _mapper.Map<TeacherResponseDto>(createdTeacher);
        }

        public async Task<bool> DeleteTeacherAsync(string teacherId)
        {
            return await _teacherRepository.DeleteAsync(teacherId);
        }

        public async Task<List<TeacherResponseDto>> GetAllTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return _mapper.Map<List<TeacherResponseDto>>(teachers);
        }

        public async Task<TeacherResponseDto?> GetTeacherByIdAsync(string teacherId)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            return teacher == null ? null : _mapper.Map<TeacherResponseDto>(teacher);
        }

        public async Task<TeacherResponseDto> UpdateTeacherAsync(string teacherId, UpdateTeacherDto updateDto)
        {
            var teacher = await _teacherRepository.UpdateAsync(teacherId, updateDto);
            return _mapper.Map<TeacherResponseDto>(teacher);
        }

    }
}
