using CourseManagementSystem.Domain.Entities;

namespace CourseManagementSystem.Application.Interfaces
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> PostCourseAsync(Course course);
    }
}
