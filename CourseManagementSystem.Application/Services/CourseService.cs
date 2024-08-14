using CourseManagementSystem.Application.Interfaces;
using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Domain.Interfaces;

namespace CourseManagementSystem.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            return course;
        }

        public async Task<Course> PostCourseAsync(Course input)
        {
            var course = await _courseRepository.PostCourseAsync(input);
            return course;
        }
    }
}
