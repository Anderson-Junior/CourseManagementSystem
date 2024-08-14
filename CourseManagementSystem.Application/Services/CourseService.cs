using AutoMapper;
using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Domain.Interfaces;
using CourseManagementSystem.Shared.Dtos.Course;

namespace CourseManagementSystem.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            return course;
        }

        public async Task<Course> PostCourseAsync(CreateCourseDto createCourseDto)
        {
            var course = _mapper.Map<Course>(createCourseDto);
            return await _courseRepository.PostCourseAsync(course);
        }
    }
}
