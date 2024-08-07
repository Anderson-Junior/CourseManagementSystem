using CourseManagementSystem.Api.Entities;

namespace CourseManagementSystem.Api.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> PostCourseAsync(Course course);
    }
}
