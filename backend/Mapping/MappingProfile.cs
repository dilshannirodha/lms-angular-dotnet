using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Student mappings
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // null-check for PATCH-style update
            CreateMap<Student, StudentResponseDto>();

            // StudentUpload mappings
            CreateMap<CreateStudentUploadDto, StudentUpload>();
            CreateMap<UpdateStudentUploadDto, StudentUpload>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<StudentUpload, StudentUploadResponseDto>();
        }
    }
}
