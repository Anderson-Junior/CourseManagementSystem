using CourseManagementSystem.Api.Entities;

namespace CourseManagementSystem.Api.Services.Interfaces
{
    public interface ICourseService
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> PostCourseAsync(Course course);
    }
}
