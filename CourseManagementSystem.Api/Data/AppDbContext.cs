using CourseManagementSystem.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }
    }
}
