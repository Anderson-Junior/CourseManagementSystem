using CourseManagementSystem.Domain.Entities;
using CourseManagementSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Infrastructure.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            var course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
            return course;
        }

        public async Task<Course> PostCourseAsync(Course course)
        {
            await _dbContext.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return course;
        }
    }
}
