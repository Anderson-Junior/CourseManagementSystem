using CourseManagementSystem.Api.Data;
using CourseManagementSystem.Api.Entities;
using CourseManagementSystem.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Api.Repositories
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
