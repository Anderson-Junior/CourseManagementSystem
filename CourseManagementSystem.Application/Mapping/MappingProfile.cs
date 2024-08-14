using AutoMapper;
using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Shared.Dtos.Course;

namespace CourseManagementSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCourseDto, Course>().ReverseMap();
        }
    }
}
