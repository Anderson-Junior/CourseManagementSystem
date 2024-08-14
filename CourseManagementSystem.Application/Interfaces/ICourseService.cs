using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Shared.Dtos.Course;

namespace CourseManagementSystem.Application.Interfaces
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> PostCourseAsync(CreateCourseDto course);
    }
}
