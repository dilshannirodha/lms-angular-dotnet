using AutoMapper;
using backend.DTOs.StudentDtos;
using backend.DTOs.StudentUploadDtos;
using backend.DTOs.TeacherDtos;
using backend.Models;

namespace backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Teacher, TeacherResponseDto>();

            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Student, StudentResponseDto>();

            CreateMap<CreateStudentUploadDto, StudentUpload>();
            CreateMap<UpdateStudentUploadDto, StudentUpload>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<StudentUpload, StudentUploadResponseDto>();
        }
    }
}
