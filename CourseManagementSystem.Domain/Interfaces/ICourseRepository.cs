using CourseManagementSystem.Domain.Entities;

namespace CourseManagementSystem.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> PostCourseAsync(Course course);
    }
}
